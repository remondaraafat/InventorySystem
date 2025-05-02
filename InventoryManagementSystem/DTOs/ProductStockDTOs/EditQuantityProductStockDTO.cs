namespace InventoryManagementSystem.DTOs.ProductStockDTOs
{
    public class EditQuantityProductStockDTO
    {
        [Key]

        public int ID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int NewQuantity { get; set; }
        public int TransactionTypeId {  get; set; }
        public int NewWarehouseId { get; set; }



    }
}
