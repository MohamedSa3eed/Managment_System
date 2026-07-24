using Managment_System.BLL.Interfaces;
using Managment_System.BLL.Repositories;
using Managment_System.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.PL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Allow Dependency Injection with Scoped Visibility
        // builder.Services.AddScoped<ApplicationDbContext>();
        // builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>();
        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer( // no need to override the OnConfiguring()
                "Server=.; Database=Company; User Id=sa; Password=zaq1@WSXcde3; Encrypt=True; TrustServerCertificate=True;"),
            contextLifetime:  ServiceLifetime.Scoped,
            optionsLifetime: ServiceLifetime.Scoped
        );

        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>(); // Allow Dependency Injection 

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}