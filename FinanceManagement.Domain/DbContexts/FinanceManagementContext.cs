using FinanceManagement.Domain.Database;
using FinanceManagement.Domain.Models.Database;

using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.Context.DbContexts
{
    public class FinanceManagementContext : DbContext
    {
        public DbSet<Accounting> Accountings {get;set;}

        public DbSet<User> Users {get;set;}

        public FinanceManagementContext()
        {

        }
        public FinanceManagementContext(DbContextOptions<FinanceManagementContext> options) : base(options)
        {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Accounting>()
        //         .Property(t =>  t.Created_at)
        //         .HasDefaultValue("now()");
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql("Host=localhost;Database=finance_management;User ID=postgres;Password=sloshy;Host=localhost;Port=5432;");
        }
    }
}