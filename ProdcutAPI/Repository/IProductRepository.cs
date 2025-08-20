using ProductAPI.Models;

namespace ProductAPI.Repository {
    public interface IProductRepository {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task DeleteAsync(int id);
    }
}
