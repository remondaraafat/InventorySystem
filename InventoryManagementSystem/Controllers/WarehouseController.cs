using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.DTOs.WarehouseDTOs;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Messaging;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        WarehouseService _warehouseService;
        public WarehouseController(WarehouseService warehouseService) {
            _warehouseService = warehouseService;
        }
        [HttpGet]
       // [Authorize("Admin")]
        public async Task<IActionResult> GetAll() {
            try
            {
                List<GetAllWarehouseDTO> DTO = await _warehouseService.GetAllWarehouseRequest();
                if(DTO==null)
                    return NotFound(new {Message="The database is empty."});

                return Ok(DTO);
            }
            catch (Exception ex) { 
               // return BadRequest(ex.Message);
                return StatusCode(500,new {Message= "An error ocured while retrieving the Warehouses." });
            }
        }
        //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateًWarehouse(CreateWarehouseDTO DTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _warehouseService.AddًWarehouseRequest(DTO);
                return StatusCode(201, new { message = "Warehouse created successfully." });

                //return CreatedAtAction(nameof(GetAll),new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while Creating the Warehouse." });
            }
        }
    }
}
