using FirstStep.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<UserContext>(option => {
    option.UseSqlite("Data Source=users.db");
});

var app = builder.Build();


app.MapControllerRoute("default", "{controller=User}/{action=Get}");

app.MapControllerRoute(
    name: "GetUserById",
    pattern: "{controller=User}/{action=GetById}/{id:int}"
);

app.MapControllerRoute(
    name: "AddUser",
    pattern: "{controller=User}/{action=AddUser}"
);

app.Run();
