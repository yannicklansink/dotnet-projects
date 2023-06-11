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

builder.Services.AddDbContext<TodoContext>(); // <- This is a method that registers the DbContext service in the DI container. 
builder.Services.AddTransient<ITodoRepository, TodoRepository>();  // <-  registers a service in the application's DI container.
builder.Services.AddSingleton<MyExceptionLoggingMiddleware>(); 


var app = builder.Build();

// all app commands are middlewares application pipeline.
app.UseDeveloperExceptionPage();
app.UseMyExceptionLogger();



app.UseStaticFiles(); // wwwroot beschikbaar stellen

app.MapRazorPages();

app.Run();
