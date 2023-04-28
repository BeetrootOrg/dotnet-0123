using Microsoft.EntityFrameworkCore;

using TaskManagement.Domain.Models.Database;

namespace TaskManagement.Domain.DbContexts
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskManagementContext()
        {
        }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is used by the EF Core CLI tools
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder.UseNpgsql("Host=localhost;Database=task_management;Username=user;Password=password");
            }
        }
    }
}