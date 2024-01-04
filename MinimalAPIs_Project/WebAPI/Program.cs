var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDb>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddScoped<IUserRepository,UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<UserDb>();

    db.Database.EnsureCreated();
}

app.MapGet("/users", async ([FromServices]UserRepository rep) => Results.Ok(await rep.GetUsersAsync()));

app.MapGet("/users/{id}", async (int id, [FromServices]UserRepository rep) => {
    User user = await rep.GetUserAsync(id);
    if (user == null) return Results.NotFound();
    return Results.Ok(user);
});

app.MapPost("/users", async ([FromBody]User user, [FromServices]UserRepository rep) =>{
    await rep.CreateUserAsync(user);
    await rep.SaveAsync();
    Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id}", async ([FromBody]User user,int id, [FromServices]UserRepository rep) => 
{
    await rep.UpdateUserAsync(id,user);
    await rep.SaveAsync();
    Results.NoContent();
});

app.MapDelete("/users/{id}", async (int id,[FromServices]UserRepository rep) => {
    await rep.RemoveUserAsync(id);
    await rep.SaveAsync();
    Results.NoContent();
});

app.Run();
