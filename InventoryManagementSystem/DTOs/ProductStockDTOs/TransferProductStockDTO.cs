namespace InventoryManagementSystem.DTOs.ProductStockDTOs
{
    public class TransferProductStockDTO
    {
        [Key]

        public int ID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int QuantityChange { get; set; }
        public int TransactionTypeId { get; set; }
        [Required(ErrorMessage = "Destination Warehouse Id is required.")]
        public int DestinationWarehouseId { get; set; }
        [Required(ErrorMessage = "Destination Stock Id is required.")]

        public int DestinatioStockId { get; set; }
    }
}
