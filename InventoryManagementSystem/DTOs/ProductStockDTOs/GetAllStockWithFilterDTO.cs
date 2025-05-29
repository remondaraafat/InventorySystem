namespace InventoryManagementSystem.DTOs.ProductStockDTOs
{
    public class GetAllStockWithFilterDTO
    {
        public int ID { get; set; }

        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int WarehouseId { get; set; }

        public String WarehouseName { get; set; }
    }
}
