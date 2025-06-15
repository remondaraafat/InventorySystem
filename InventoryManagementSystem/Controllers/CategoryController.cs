
using InventoryManagementSystem.CQRS.CategoryCQRS.Command;
using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService _categoryService;
        IMediator _mediator;
        public CategoryController(CategoryService CategoryService,IMediator mediator)
        {
            _categoryService = CategoryService;
            _mediator = mediator;
        }

       // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //List<GetAllCategoryDTO> DTO = await _categoryService.GetAllCategoryRequest();
                //if (DTO == null)
                //    return NotFound(new { message = "The Database is empty." });

                //return Ok(DTO);
                List<GetAllCategoryDTO> DTO = await _mediator.Send(new GetAllCategoryQuery());
                if (DTO == null)
                    return NotFound(new { message = "The Database is empty." });
                return Ok(DTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the Categories." });
            }
        }

        
      //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCateoryDTO DTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //await _categoryService.AddCategoryRequest(DTO);
                await _mediator.Send(new AddCategoryQuery { Name=DTO.Name});
                return StatusCode(201, new { message = "Category created successfully." });

                //return CreatedAtAction(nameof(GetAll),new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while Creating the Category." });
            }
        }
    }
}
/// ===== get all cat =====
///  1 - inject IMediator
/// 2- use send function in mediator
/// send => send request to mediator 
/// send => take class implement IRequest
/// send will always take the class i created for this end point
/// send(GetAllCategoryQuery)
/// send => search for the handeler of the class i passed to the send()
/// mediator => وسيط بيساعدنى اوصل للهاندلر
/// 
