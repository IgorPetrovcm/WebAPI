using Authorization.Application.Interfaces.Services;
using Authorization.Application.Interfaces.Repository;
using Authorization.Persistence.Repository;  
using Authorization.Persistence;
using Authorization.Infrastructure.Services;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
});

builder.Services.AddTransient<IConfigurationManageService, ConfigurationManageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();