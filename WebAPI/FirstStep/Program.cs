using FirstStep.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>(option => {
    option.UseSqlite("Data Source=users.db");
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
