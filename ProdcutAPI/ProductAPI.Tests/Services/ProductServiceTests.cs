using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Tests.Services {
    public class ProductServiceTests {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _controller;

        public ProductServiceTests() {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WithProducts() {
            // Arrange
            var mockProducts = new List<Product> {
                new Product{id = 1, Name= "Laptop", Price = 1500}
            };

            _mockService.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(mockProducts);

            //Act
            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsType<List<Product>>(okResult.Value);
            // TODO!: i need to clean the db maybe fresh migration
            Assert.Single(products); 
        }

        [Fact]
        public async Task Add_ShouldReturnOkResult_WithCreatedProduct() {
            // Arrange
            var productDto = new ProductDTO { Name = "Keyboard", Price = 100 };
            var createdProduct = new Product { id = 1, Name = "Keyboard", Price = 100 };

            _mockService.Setup(s => s.AddProductAsync(productDto)).ReturnsAsync(createdProduct);

            // Act
            var result = await _controller.Add(productDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(1, product.id);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccessful() {
            // Arrange
            _mockService.Setup(service => service.DeleteProductAsync(1))
                       .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
