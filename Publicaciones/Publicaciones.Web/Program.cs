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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /// Add context dependencies
			builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

            // Repositories dependencies
            builder.Services.AddAuthorsDependency();
            builder.Services.AddTitleAuthorDependency();

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