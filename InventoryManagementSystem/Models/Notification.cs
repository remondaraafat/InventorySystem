namespace InventoryManagementSystem.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime NotificationDate { get; set; }
        public bool IsSent { get; set; }
    }
}
