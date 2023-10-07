using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            /// Add context dependencies
            builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

            // Repositories dependencies

            builder.Services.AddTransient<IPub_InfoRepository, Pub_InfoRepository>();
            builder.Services.AddTransient<IRoySchedRepository, RoySchedRepository>();
            builder.Services.AddTransient<ITitlesRepository, TitlesRepository>();


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