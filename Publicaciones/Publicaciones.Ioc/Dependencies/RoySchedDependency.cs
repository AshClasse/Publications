using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
	public static class RoySchedDependency
	{
		public static void AddRoySchedDependency(this IServiceCollection service)
		{
			service.AddScoped<IRoySchedRepository, RoySchedRepository>();
			service.AddTransient<IRoySchedService, RoySchedService>();
		}
	}
}
