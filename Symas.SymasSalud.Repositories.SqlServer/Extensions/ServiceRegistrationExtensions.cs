using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Symas.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symas.SymasSalud.Repositories.SqlServer.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddSymasSaludDbContext(
            this IServiceCollection service,
            Action<DbContextOptionsBuilder> options)
        {
            service.RequireThat().NotNull();

            service.AddDbContext<SymasSaludDbContext>(options);

            return service;
        }

        public static IServiceCollection AddSymasSaludRepositories(
            this IServiceCollection service)
        {
            service.RequireThat().NotNull();

            service.AddScoped<IProductRepository, ProductRepository>();
            
            return service;
        }
    }
}
