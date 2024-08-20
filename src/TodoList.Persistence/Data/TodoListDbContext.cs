using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.Domain.Entities;

namespace Todo.Persistence.Data
{
    public class TodoListDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public DbSet<TodoList> TodoLists => Set<TodoList>();

        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
