using Microsoft.EntityFrameworkCore;
using ProdcutAPI.Data;
using ProdcutAPI.Models;

namespace ProdcutAPI.Repository {
    public class ProductRepository : IProductRepository{
        // get context
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        // interface
        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();  
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
        public async Task<Product> AddAsync(Product product) {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id) {
            var product = await GetByIdAsync(id);
            if (product is not null) _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
