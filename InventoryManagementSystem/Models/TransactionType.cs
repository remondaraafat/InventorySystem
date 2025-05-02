using ServiceStack.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class TransactionType:BaseModel
    {
        [Unique]
        public string Name { get; set; }
        public ICollection<TransactionType> TransactionTypes { get; set; }  
    }
}
