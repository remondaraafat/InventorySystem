namespace InventoryManagementSystem.DTOs.TransactionHistoryDTOs
{
    public class GetTransactioHistoryWithFilterDTO
    {
        public int ID { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }


        public DateTime TransactionDate { get; set; }

        public bool Archived { get; set; } = false;

        public string UserId { get; set; }

        public string UserName { get; set; }

        // not fk
        public int? FromWarehouseId { get; set; }

        public string? FromWarehouseName { get; set; }

        public int? ToWarehouseId { get; set; }

        public string? ToWarehouseName { get; set; }

        public int TransactionTypeId { get; set; }

        public string TransactionTypeName { get; set; } 
    }
}
