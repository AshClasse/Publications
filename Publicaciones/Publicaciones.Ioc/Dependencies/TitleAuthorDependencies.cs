using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Ioc.Dependencies
{
    public static class TitleAuthorDependencies
    {
        public static void AddTitleAuthorDependency(this IServiceCollection service)
        {
            service.AddScoped<ITitleAuthorRepository, TitleAuthorRepository>();
            service.AddTransient<ITitleAuthorService, TitleAuthorService>();
        }
    }
}
