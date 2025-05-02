using SCDS = System.ComponentModel.DataAnnotations.Schema;
using SCD = System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTOs.ProductDTOs
{
    public class EditProductDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [SCD.Required(ErrorMessage = "Product name is required.")]
        [SCD.StringLength(100, ErrorMessage = "Product name can't exceed 100 characters.")]
        [Unique] // ORM => search ?? 
        public string ProductName { get; set; }

        [SCD.StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string? ProductDescription { get; set; }

        [SCD.Range(0, int.MaxValue, ErrorMessage = "Low stock threshold must be a non-negative number.")]
        public int ProductLowStockThreshold { get; set; }

        [SCD.Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal ProductPrice { get; set; }

        [SCDS.ForeignKey("Category")]
        [SCD.Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

    }
}
