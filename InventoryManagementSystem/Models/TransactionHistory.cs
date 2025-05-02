using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Models
{
    public class TransactionHistory : BaseModel
    {

        
            public int ProductId { get; set; }
            public Product Product { get; set; }

            public int Quantity { get; set; }
            public DateTime TransactionDate { get; set; }
            public bool Archived { get; set; }
            public string UserId { get; set; }
            public IdentityUser User { get; set; }
        //not foreign key
            public int? FromWarehouseId { get; set; }
            public Warehouse? FromWarehouse { get; set; }

            public int? ToWarehouseId { get; set; }
            public Warehouse? ToWarehouse { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }        // Increase, Decrease, Transfer

        

    }
    //public enum TransactionType
    //{
    //    Add,
    //    Remove,
    //    Transfer
    //}
}
