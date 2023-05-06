using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductsContext() : base()
        {
        }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
    }
}