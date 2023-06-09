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

builder.Services.AddDbContext<TodoContext>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();  // <-  registers a service in the application's dependency injection (DI) container.
builder.Services.AddSingleton<MyExceptionLoggingMiddleware>();


var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseMyExceptionLogger();



app.UseStaticFiles(); // wwwroot beschikbaar stellen

app.MapRazorPages();

app.Run();
