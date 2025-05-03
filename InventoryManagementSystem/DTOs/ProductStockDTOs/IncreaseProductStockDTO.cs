namespace InventoryManagementSystem.DTOs.ProductStockDTOs
{
    public class IncreaseProductStockDTO
    {
        [Key]

        public int ID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int QuantityChange { get; set; }
        public int TransactionTypeId {  get; set; }



    }
}
