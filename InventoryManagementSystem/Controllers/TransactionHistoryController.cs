using InventoryManagementSystem.DTOs.ProductStockDTOs;
using InventoryManagementSystem.DTOs.TransactionHistoryDTOs;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        TransactionHistoryService _transactionHistoryService;
        public TransactionHistoryController(TransactionHistoryService transactionHistoryService) { 
            _transactionHistoryService = transactionHistoryService;
        }
        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> GetTransactionReport([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10  , [FromQuery]  DateTime? date=null, [FromQuery] int? productId=null)
        {
            if (pageSize > 50)
            {
                ModelState.AddModelError(nameof(pageSize), "Page size should be 50 or less.");
                return BadRequest(ModelState);
            }
            try
            {
                List<GetTransactioHistoryWithFilterDTO> DTO = await _transactionHistoryService.TransactionReportRequest(pageNumber, pageSize, date,productId);
                if (DTO == null || !DTO.Any())
                    return NotFound(new { message = "No transactions found with the given filters." });

                return Ok(DTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the low stock report." });
            }
        }
    }
}
