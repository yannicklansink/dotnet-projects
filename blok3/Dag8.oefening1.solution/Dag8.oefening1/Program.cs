using Dag8.oefening1.Dal;
using Dag8.oefening1.Middleware;
using Dag8.oefening1.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddRazorPages() // registreet functinoaliteit
    .AddRazorPagesOptions(o =>
    {
        o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
    });

builder.Services.AddDbContext<TodoContext>(options =>
{
    var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=dotnet7todoappdb;TrustServerCertificate=True; Integrated Security=true";
    options.UseSqlServer(connectionString);

}); // <- This is a method that registers the DbContext service in the DI container.
    // 

builder.Services.AddControllers(); 

builder.Services.AddTransient<ITodoRepository, TodoRepository>();  // <-  registers a service in the application's DI container.
builder.Services.AddSingleton<MyExceptionLoggingMiddleware>(); 




var app = builder.Build();

// setup localdb 
using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<TodoContext>();
context.Database.EnsureCreated();




// all app commands are middlewares application pipeline.
app.UseDeveloperExceptionPage();
//app.UseMyExceptionLogger();



app.UseStaticFiles(); // wwwroot beschikbaar stellen

app.MapControllers(); // controllers beschikbaar stellen

app.MapRazorPages();

app.Run();
