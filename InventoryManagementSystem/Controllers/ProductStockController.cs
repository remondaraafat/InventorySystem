using InventoryManagementSystem.DTOs.ProductStockDTOs;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        ProductStockService _productStockService;
        public ProductStockController(ProductStockService productStockService)
        {
            _productStockService = productStockService;
        }
        //increase
        [HttpPut("Increase")]
        [Authorize("Admin")]
        public async Task<IActionResult> IncreseStock(IncreaseProductStockDTO DTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "User is not authenticated." });

                if (await _productStockService.IncreaseStockAndLogTransactionRequest(DTO, userId))
                    return Ok(new { message = "Product stock updated successfully." });
                return NotFound(new { message = "Can't complete this transaction." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product stock." });
            }

        }
        //decrease
        [HttpPut("Decrease")]
        [Authorize("Admin")]
        public async Task<IActionResult> DecreaseStock(DecreaseProductStockDTO DTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "User is not authenticated." });

                if (await _productStockService.DecreaseStockAndLogTransactionRequest(DTO, userId))
                    return Ok(new { message = "Product stock updated successfully." });
                return NotFound(new { message = "Can't complete this transaction." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product stock." });
            }

        }
        //transfer
        [HttpPut("Transfer")]
        [Authorize("Admin")]
        public async Task<IActionResult> TransferStock(TransferProductStockDTO DTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "User is not authenticated." });


                if (await _productStockService.TransferStockAndLogTransactionRequest(DTO, userId))
                    return Ok(new { message = "Product stock updated successfully." });
                return NotFound(new { message = "Can't complete this transaction." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product stock." });
            }

        }
        //low stock
        [HttpGet("lowStock")]
        //  [Authorize("Admin")]
        public async Task<IActionResult> GetLowStockReport([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) 
        {
            if (pageSize > 50)
            {
                ModelState.AddModelError(nameof(pageSize), "Page size should be 50 or less.");
                return BadRequest(ModelState);
            }
            try
            {
                List<LowStockDTO> lowStockDTO = await _productStockService.LowStockRequest(pageNumber,pageSize);
                if (lowStockDTO == null||!lowStockDTO.Any())
                    return NotFound(new { message = "All products are above the low stock threshold.." });

                return Ok(lowStockDTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the low stock report." });
            }
        }
        [HttpGet("StockFilter")]
        //  [Authorize("Admin")]
        public async Task<IActionResult> GetAllStockWithFilterReport([FromQuery] int productID, [FromQuery] int warehouseID,[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageSize > 50)
            {
                ModelState.AddModelError(nameof(pageSize), "Page size should be 50 or less.");
                return BadRequest(ModelState);
            }
            try
            {
                List<GetAllStockWithFilterDTO> DTO = await _productStockService.GetAllStockwithFilterRequest(pageNumber, pageSize,productID,warehouseID);
                if (DTO == null || !DTO.Any())
                    return NotFound(new { message = "Stock not found." });

                return Ok(DTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the stock report." });
            }
        }
    }
}
