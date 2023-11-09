using Microsoft.Extensions.DependencyInjection;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Service;
using Publicaciones.Application.Validations.ContractValidations;
using Publicaciones.Application.Validations.ServicesValidations;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Ioc.Dependencies
{
    public static class EmployeeDependency
    {
        public static void AddEmployeeDependency(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeValidations, EmployeeValidations>();
        }
    }
}
