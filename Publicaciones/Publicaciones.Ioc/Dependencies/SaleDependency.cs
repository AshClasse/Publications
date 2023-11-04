using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Services;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class SaleDependency
    {
        public static void AddSaleDependency(this IServiceCollection service)
        {
            service.AddScoped<ISaleRepository, SaleRepository>();
            service.AddTransient<ISaleService, SaleService>();
        }
    }
}
