using ServiceStack.DataAnnotations;

namespace InventoryManagementSystem.DTOs.Product
{
    public class GetProductDTO
    {
        public int ID { get; set; }
        [Unique]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductLowStockThreshold { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
