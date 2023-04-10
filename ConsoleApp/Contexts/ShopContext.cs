using System;

using ConsoleApp.Models;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts
{
    public class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql("User ID=user;Password=password;Host=localhost;Port=5432;Database=shop2;");
            _ = optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.LastName, c.FirstName });

            _ = modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            _ = modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    b => _ = b.HasOne(x => x.Product).WithMany(),
                    b => _ = b.HasOne(x => x.Order).WithMany()
            );
        }
    }
}