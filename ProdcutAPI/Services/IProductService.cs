using ProductAPI.Models;

namespace ProductAPI.Services {
    public interface IProductService {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(ProductDTO productDto);
        Task DeleteProductAsync(int id);
    }
}
