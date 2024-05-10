
using CrudAPI.Core.Application.Interfaces.Services;
using CrudAPI.Core.Application.Interfaces.Services.UserToDoService;
using CrudAPI.Core.Application.Services;
using CrudAPI.Core.Application.Services.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrudAPI.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient<IUserTodoService, UserToDoService>();
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericServices<,,>));
            #endregion
        }
    }
}
