using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Models
{
    [Index(nameof(ProductId), nameof(WarehouseId), IsUnique = true)]
    public class ProductStock : BaseModel
    {
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "WarehouseId is required.")]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
