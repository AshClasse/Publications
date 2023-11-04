using Microsoft.EntityFrameworkCore;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Ioc.EmployeeDependency;
using Publicaciones.Ioc.JobDependency;
using Publicaciones.Ioc.PublisherDependency;

namespace Publicaciones.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Agregar dependencia del contexto //

            var connectionString = builder.Configuration.GetConnectionString("DBpublicaciones");

            builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(connectionString));

            //Dependencias de los respositorios//

            builder.Services.AddJobDependency();
            builder.Services.AddEmployeeDependency();
            builder.Services.AddPublisherDependency();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}