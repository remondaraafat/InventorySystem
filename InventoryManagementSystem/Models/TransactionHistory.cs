using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Models
{
    public class TransactionHistory
    {
       
            public int TransactionId { get; set; }

            public int ProductId { get; set; }
            public Product Product { get; set; }

            public int Quantity { get; set; }
            public string TransactionType { get; set; } // Add, Remove, Transfer
            public DateTime TransactionDate { get; set; }

            public string UserId { get; set; }
            public IdentityUser User { get; set; }

            public int? FromWarehouseId { get; set; }
            public Warehouse? FromWarehouse { get; set; }

            public int? ToWarehouseId { get; set; }
            public Warehouse? ToWarehouse { get; set; }
        

    }
}
