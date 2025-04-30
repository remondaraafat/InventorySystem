namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int LowStockThreshold { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<TransactionHistory> TransactionHistorys { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
