namespace InventoryManagementSystem.DTOs.WarehouseDTOs
{
    public class CreateWarehouseDTO
    {
        [Required(ErrorMessage = "Warehouse name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Warehouse name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Location must not exceed 200 characters.")]
        public string? Location { get; set; }
    }
}
