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
    }
}
