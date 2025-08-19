using ProdcutAPI.Models;
using ProdcutAPI.Repository;

namespace ProdcutAPI.Services {
    public class ProductService: IProductService {
        //repo
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repo) => _repository = repo;

        //interface
        public Task<List<Product>> GetAllProductsAsync() => _repository.GetAllAsync();
        public Task<Product?> GetProductByIdAsync(int id) => _repository.GetByIdAsync(id);
        public async Task<Product> AddProductAsync(ProductDTO productDto) {
            var newProduct = new Product { 
                Name = productDto.Name,
                Description = productDto.Description, 
                Price=productDto.Price
            };
            return await _repository.AddAsync(newProduct);
        }

        public Task DeleteProductAsync(int id) => _repository.DeleteAsync(id);

    }
}
