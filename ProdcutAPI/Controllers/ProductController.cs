using Microsoft.AspNetCore.Mvc;
using ProdcutAPI.Models;
using ProdcutAPI.Services;

namespace ProdcutAPI.Controllers {

    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase{
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll()=> Ok(await _productService.GetAllProductsAsync());
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _productService.GetProductByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO productDTO) => Ok(await _productService.AddProductAsync(productDTO));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
