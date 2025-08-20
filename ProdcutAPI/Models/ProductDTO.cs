using System.ComponentModel.DataAnnotations;

namespace ProdcutAPI.Models {
    public class ProductDTO {
        [Required]
        [StringLength(100)]
        public required string Name {  get; set; }
        public string? Description { get; set; }
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
    }
}
