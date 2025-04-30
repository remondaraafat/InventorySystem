namespace InventoryManagementSystem.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }

        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
