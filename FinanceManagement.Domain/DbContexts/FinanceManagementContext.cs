
using FinanceManagement.Domain.Models.Database;

using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.Context.DbContexts
{
    public class FinanceManagementContext : DbContext
    {
        public DbSet<Accounting> Accountings {get;set;}

        public DbSet<Iteration> Iterations {get;set;}

        public FinanceManagementContext()
        {

        }
        public FinanceManagementContext(DbContextOptions<FinanceManagementContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql("Host=localhost;Database=finance_management;User ID=postgres;Password=sloshy;Host=localhost;Port=5432;");
        }
    }
}