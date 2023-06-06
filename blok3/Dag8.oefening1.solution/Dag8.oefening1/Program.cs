using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorPages() // registreet functinoaliteit
    .AddRazorPagesOptions(o =>
    {
        o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
    });

var app = builder.Build();

app.UseStaticFiles(); // wwwroot beschikbaar stellen

app.MapRazorPages();

app.Run();
