using Microsoft.EntityFrameworkCore;
using Pronia_Project.Models;

namespace Pronia_Project.Datas
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) {
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
