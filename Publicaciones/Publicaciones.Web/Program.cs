using Microsoft.EntityFrameworkCore;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Ioc.Dependencies;

namespace Publicaciones.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

			// Add context dependencies
			builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

			// Dependencias de los servicios

			builder.Services.AddPubInfoDependency();
			builder.Services.AddRoySchedDependency();
			builder.Services.AddTitlesDependency();


			// Add services to the container.
			builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}