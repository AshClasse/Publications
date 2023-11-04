using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.EmployeeDependency
{
    public static class EmployeeDependency
    {
        public static void AddEmployeeDependency(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
