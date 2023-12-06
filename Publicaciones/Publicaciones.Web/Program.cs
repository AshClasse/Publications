using Microsoft.EntityFrameworkCore;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Ioc.Dependencies;
using Publicaciones.Web.Service;

namespace Publicaciones.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

            builder.Services.AddDiscountDependency();
            builder.Services.AddSaleDependency();
            builder.Services.AddStoreDependency();
            builder.Services.AddScoped<IApiService, ApiService>();


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