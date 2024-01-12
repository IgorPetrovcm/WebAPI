using Authorization.Application.Interfaces.Services;
using Authorization.Application.Interfaces.Repository;
using Authorization.Persistence.Repository;  
using Authorization.Persistence;
using Authorization.Infrastructure.Services;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
});

builder.Services.AddTransient<IConfigurationManageService, ConfigurationManageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.MapControllerRoute("default", "{controller=UserAuth}/{action=Register}");

app.Run();