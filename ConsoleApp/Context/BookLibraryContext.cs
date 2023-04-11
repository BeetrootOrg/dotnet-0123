using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;

namespace ConsoleApp.Context
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<History> Histories { get; set; }
        public BookLibraryContext() : base()
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=book_library;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(a => new { a.FirstName, a.LastName });

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.FirstName, c.LastName });

            modelBuilder.Entity<History>()
                .ToTable("tbl_history", t => t.HasCheckConstraint("direction", "direction IN ('IN', 'OUT')"));
        }
    }
}