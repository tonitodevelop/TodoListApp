using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Todo.Application.Services;

namespace Todo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ITodoItemService, TodoItemService>();
            services.AddTransient<ITodoListService, TodoListService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
