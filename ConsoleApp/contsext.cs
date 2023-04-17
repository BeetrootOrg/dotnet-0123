using System;
using Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    public class Context : DbContext
    {
        public DbSet<Histiry> Histiries {get;set;}
        public DbSet<Author> Authors {get;set;}
        public DbSet<Customer> Customers  {get;set;}
        public DbSet<Book> Books {get;set;}
        public Context() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=localhost;Port=5432;Database=db;");
        }
    }
}