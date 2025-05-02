using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Warehouse : BaseModel
    {
        [Unique]
        public string Name { get; set; }
        public string? Location { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
