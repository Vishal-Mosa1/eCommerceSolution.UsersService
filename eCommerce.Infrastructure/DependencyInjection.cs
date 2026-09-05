using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Add services to the IOC Container
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
