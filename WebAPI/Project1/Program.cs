using Microsoft.EntityFrameworkCore;
using Project1;
using Project1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(option =>{
    option.UseSqlite("Data Source=project1.db");
});

var app = builder.Build();

app.MapControllers();

app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
