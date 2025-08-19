namespace ProdcutAPI.Models {
    public class ProductDTO {
        public required string Name {  get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
