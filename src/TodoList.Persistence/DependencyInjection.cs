using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Common.Interfaces;
using Todo.Persistence.Data;
using Todo.Persistence.Repositories;

namespace Todo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoListDbContext>(options => options.UseSqlite(configuration.GetConnectionString("TodoListConnection")));
            //services.AddScoped<ITodoListDbContext>(provider => provider.GetRequiredService<TodoListDbContext>());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            /*services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
