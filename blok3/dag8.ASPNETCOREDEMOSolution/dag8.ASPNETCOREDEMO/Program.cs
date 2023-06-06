var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages(); // gaat binnen project kijken welke er zijn

app.Run();




