using Persistence.DataContext;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddScoped<IUserDbRepository,UserDbRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();