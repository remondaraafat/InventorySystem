using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.DTOs.TransactionTypeDTOs;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        TransactionTypeService _transactionTypeService;
        public TransactionTypeController(TransactionTypeService TransactionType)
        {
            _transactionTypeService = TransactionType;
        }

     //   [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<GetAllTransactionTypeDTO> DTO = await _transactionTypeService.GetAllTransactionTypeRequest();
                if (DTO == null)
                    return NotFound(new { message = "The Database is empty." });

                return Ok(DTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the Transaction Types." });
            }
        }


     //   [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateTransactionType(CreateTransactionTypeDTO DTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _transactionTypeService.AddTransactionTypeRequest(DTO);
                return StatusCode(201, new { message = "Transaction Type created successfully." });

                // return CreatedAtAction(nameof(GetAll), new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while Creating the Category." });
            }
        }
    }
}
