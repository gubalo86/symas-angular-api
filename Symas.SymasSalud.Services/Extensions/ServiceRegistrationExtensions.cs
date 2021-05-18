using Microsoft.Extensions.DependencyInjection;
using Symas.Core.Validation;
using Symas.SymasSalud.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symas.SymasSalud.Services.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddSymasSaludServices(
            this IServiceCollection service)
        {
            service.RequireThat().NotNull();
            service.AddScoped<IProductService, ProductService>();
            return service;
        }
    }
}
