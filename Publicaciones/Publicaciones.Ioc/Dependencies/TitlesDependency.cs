using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
	public static class TitlesDependency
	{
		public static void AddTitlesDependency(this IServiceCollection service)
		{
			service.AddScoped<ITitlesRepository, TitlesRepository>();
			service.AddTransient<ITitlesService, TitlesService>();
		}
	}
}
