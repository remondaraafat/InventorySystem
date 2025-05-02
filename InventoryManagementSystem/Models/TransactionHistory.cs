using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Models
{
    public class TransactionHistory : BaseModel
    {
        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "TransactionDate is required.")]
        public DateTime TransactionDate { get; set; }

        public bool Archived { get; set; }= false;

        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // not fk
        public int? FromWarehouseId { get; set; }

        public Warehouse? FromWarehouse { get; set; }

        public int? ToWarehouseId { get; set; }

        public Warehouse? ToWarehouse { get; set; }

        [Required(ErrorMessage = "TransactionTypeId is required.")]
        public int TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; } // Increase, Decrease, Transfer
    }
    //public enum TransactionType
    //{
    //    Add,
    //    Remove,
    //    Transfer
    //}
}
