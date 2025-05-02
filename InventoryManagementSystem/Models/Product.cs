using  System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InventoryManagementSystem.Models
{
    public class Product : BaseModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name can't exceed 100 characters.")]
        
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Low stock threshold must be a non-negative number.")]
        public int LowStockThreshold { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<TransactionHistory> TransactionHistorys { get; set; } = new List<TransactionHistory>();
        public ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
