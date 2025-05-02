using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.DTOs.TransactionHistoryDTOs
{
    public class AddTransactionHistoryDTO
    {

        

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "TransactionDate is required.")]
        public DateTime TransactionDate { get; set; }= DateTime.Now;

        public bool Archived { get; set; }=false;

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = "TransactionTypeId is required.")]
        public int TransactionTypeId { get; set; }
        // not fk
        public int? FromWarehouseId { get; set; }
        public int? ToWarehouseId { get; set; }
 
    }
}
