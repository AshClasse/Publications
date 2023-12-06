using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class AuthorsDependencies
    {
        public static void AddAuthorsDependency(this IServiceCollection service)
        { 
            service.AddScoped<IAuthorsRepository, AuthorsRepository>();
            service.AddTransient<IAuthorsService, AuthorsService>();
        }
    }
}
