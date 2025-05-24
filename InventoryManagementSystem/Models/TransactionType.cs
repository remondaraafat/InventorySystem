
namespace InventoryManagementSystem.Models
{
    public class TransactionType:BaseModel
    {

        public string Name { get; set; }
        public ICollection<TransactionHistory> TransactionHistories { get; set; }  
    }
}
