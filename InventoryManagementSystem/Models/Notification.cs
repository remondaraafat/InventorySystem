using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Notification : BaseModel
    {


        [Required(ErrorMessage = "Notification date is required.")]
        public DateTime NotificationDate { get; set; }

        public bool IsSent { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
