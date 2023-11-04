using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.PublisherDependency
{
    public static class PublisherDependency
    {
        public static void AddPublisherDependency(this IServiceCollection services)
        {
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IPublisherService, PublisherService>();
        }
    }
}
