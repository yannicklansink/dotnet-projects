using CASE.YL.WebApp.Dal;
using CASE.YL.WebApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Text.Json.Serialization;

namespace CASE.YL.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Standard/Index", "");
            });


            builder.Services.AddDbContext<CursusContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CursusContext"));
                //var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=dotnet7cursus;TrustServerCertificate=True; Integrated Security=true";
                //options.UseSqlServer(connectionString);

            });

            builder.Services.AddControllers()
                // important for handling scenarios where you have circular references in your object graphs.
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddTransient<ICursusRepository, CursusRepository>();
            builder.Services.AddTransient<ICursistRepository, CursistRepository>();

            var app = builder.Build();

            // setup localdb 
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetService<CursusContext>();
            context.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }


    }
}