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
    }
}