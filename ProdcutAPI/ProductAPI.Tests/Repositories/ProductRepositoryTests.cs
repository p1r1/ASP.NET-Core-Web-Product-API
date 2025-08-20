using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Repository;
using Xunit;

namespace ProductAPI.Tests.Repositories {
    public class ProductRepositoryTests {
        private readonly AppDbContext _context;
        private readonly ProductRepository _repository;

        public ProductRepositoryTests() {
            // In-memory database for testing
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _repository = new ProductRepository(_context);
        }


        [Fact]
        public async Task AddAsync_ShouldAddProductToDatabase() {
            // Arrange
            var product = new Product { Name = "Test Product", Price = 100 };

            // Act
            var result = await _repository.AddAsync(product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
            Assert.True(result.id > 0);

            // Verify it's actually in the database
            var fromDb = await _context.Products.FindAsync(result.id);
            Assert.NotNull(fromDb);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts() {
            // Arrange
            _context.Products.AddRange(
                new Product { Name = "Product 1", Price = 100 },
                new Product { Name = "Product 2", Price = 200 }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenExists() {
            // Arrange
            var product = new Product { Name = "Test Product", Price = 100 };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(product.id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldRemoveProduct() {
            // Arrange
            var product = new Product { Name = "To Delete", Price = 100 };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(product.id);

            // Assert
            var fromDb = await _context.Products.FindAsync(product.id);
            Assert.Null(fromDb);
        }

        public void Dispose() {
            _context?.Dispose();
        }
    }
}
