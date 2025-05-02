using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Category:BaseModel
    {
        [Unique]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
