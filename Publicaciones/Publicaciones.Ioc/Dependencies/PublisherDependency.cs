using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Application.Validations.ContractValidations;
using Publicaciones.Application.Validations.ServicesValidations;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class PublisherDependency
    {
        public static void AddPublisherDependency(this IServiceCollection services)
        {
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IPublisherValidations, PublisherValidations>();
        }
    }
}
