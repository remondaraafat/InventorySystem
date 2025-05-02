using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InventoryManagementSystem.Models
{
    public class Category:BaseModel
    {

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
