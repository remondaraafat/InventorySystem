using InventoryManagementSystem.DTOs.Product;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _productService;
        public ProductController(ProductService ProductService) {
            _productService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllById() {
            try
            {
                List<GetAllProductDTO> productsDTO = await _productService.GetAllProductRequest();
                if (productsDTO == null)
                    return NotFound(new { message = "The Database is empty." });

                return Ok(productsDTO);
            }
            catch (Exception ex) {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the products." });
            }
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                GetProductDTO productDTO = await _productService.GetProductRequest(id);
                if (productDTO == null)
                    return NotFound(new { message = "Product not found." });

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, new { message = "An error occurred while retrieving the product." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                GetProductDTO ProductDTO= await _productService.AddProductRequest(productDTO);
                return CreatedAtAction(nameof(GetById), new { id = ProductDTO.ID }, ProductDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while Creating the product." });
            }
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if (await _productService.EditProductRequest(productDTO))
                    return Ok(new { message = "Product updated successfully." });
                return NotFound(new { message = "Product not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product." });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( int id)
        {
            try
            {
                if (await _productService.DeleteRequest(id))
                    return Ok(new { message = "Product deleted successfully." });
                return NotFound("Product not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the product." });
            }
        }
    }
}
