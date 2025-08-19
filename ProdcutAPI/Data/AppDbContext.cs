using Microsoft.EntityFrameworkCore;
using ProdcutAPI.Models;

namespace ProdcutAPI.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
