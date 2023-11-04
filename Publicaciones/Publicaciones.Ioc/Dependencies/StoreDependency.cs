using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Services;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class StoreDependency
    {
        public static void AddStoreDependency(this IServiceCollection service)
        {
            service.AddScoped<IStoreRepository, StoreRepository>();
            service.AddTransient<IStoreService, StoreService>();
        }
    }
}
