var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDb>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<UserDb>();

    db.Database.EnsureCreated();
}

app.MapGet("/users", async (UserDb db) => await db.users.ToListAsync());

app.MapGet("/users/{id}", async (int id, [FromServices]UserDb db) => {
    User user = await db.users.FirstOrDefaultAsync(x => x.Id == id);
    if (user == null) return Results.NotFound();
    return Results.Ok(user);
});

app.MapPost("/users", async ([FromBody]User user, [FromServices]UserDb db) =>{
    if (user != null)
    {
        await db.users.AddAsync(user);
        await db.SaveChangesAsync();
        Results.Created($"/users/{user.Id}",user);
    }
    else Results.NotFound();
});

app.MapPut("/users/{id}", async ([FromBody]User user,int id, [FromServices]UserDb db) => 
{
    User currentUser = await db.users.FirstOrDefaultAsync(x => x.Id == id);
    if(currentUser != null)
    {
        currentUser.Age = user.Age;
        currentUser.Name = user.Name;
        db.users.Update(currentUser);
        await db.SaveChangesAsync();
        Results.NoContent();
    }
    else Results.NotFound();
});

app.MapDelete("/users/{id}", async (int id,[FromServices]UserDb db) => {
    User user = await db.users.FirstOrDefaultAsync(x => x.Id == id);
    if (user != null)
    {
        db.users.Remove(user);
        await db.SaveChangesAsync();
        Results.NoContent();
    }
    else Results.NotFound();
});

app.Run();

public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options) : base(options) {}

    public DbSet<User> users => Set<User>();
}
public class User
{
    public int Id {get;set;}

    public string? Name {get;set;} = "";

    public int Age {get; set;}
}