using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.JobDependency
{
    public static class JobDependency
    {
        public static void AddJobDependency(this IServiceCollection services)
        {
            services.AddScoped<IJobsRepository, JobRepository>();
            services.AddTransient<IJobsService, JobsService>();
        }
    }
}
