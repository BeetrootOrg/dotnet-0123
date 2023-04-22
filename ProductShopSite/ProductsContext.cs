using Microsoft.EntityFrameworkCore;

using ProductShopSite.Models;

namespace ProductShopSite
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