using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Notification : BaseModel
    {
    

        public DateTime NotificationDate { get; set; }
        public bool IsSent { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
