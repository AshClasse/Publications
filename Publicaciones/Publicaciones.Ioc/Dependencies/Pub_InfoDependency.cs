using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
	public static class Pub_InfoDependency
	{
		public static void AddPubInfoDependency(this IServiceCollection service)
		{
			service.AddScoped<IPub_InfoRepository, Pub_InfoRepository>();
			service.AddTransient<IPub_InfoService, Pub_InfoService>();
		}
	}
}
