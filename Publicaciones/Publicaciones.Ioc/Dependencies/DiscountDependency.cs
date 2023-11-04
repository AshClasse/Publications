using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Services;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class DiscountDependency
    {
        public static void AddDiscountDependency(this IServiceCollection service)
        {
            service.AddScoped<IDiscountRepository, DiscountRepository>();
            service.AddTransient<IDiscountService, DiscountService>();
        }
    }
}
