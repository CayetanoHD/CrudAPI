using CrudAPI.Core.Application.Interfaces.Repositories;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using CrudAPI.Infrastructure.Persistence.Context;
using CrudAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CRUDConnection"), m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserToDoRepository, UserToDoRepository>();

            #endregion
        }


    }
}

