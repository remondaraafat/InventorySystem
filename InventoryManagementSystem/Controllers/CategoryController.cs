using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.Services;
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
        public CategoryController(CategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

       // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<GetAllCategoryDTO> DTO = await _categoryService.GetAllCategoryRequest();
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
                await _categoryService.AddCategoryRequest(DTO);
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
