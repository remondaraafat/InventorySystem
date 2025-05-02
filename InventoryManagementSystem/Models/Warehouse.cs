

namespace InventoryManagementSystem.Models
{
    public class Warehouse : BaseModel
    {

        public string Name { get; set; }
        public string? Location { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
