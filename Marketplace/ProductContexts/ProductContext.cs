using Marketplace.Models;

using Microsoft.EntityFrameworkCore;

namespace Marketplace.ProductContexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext() : base()
        {
        }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

    }
}