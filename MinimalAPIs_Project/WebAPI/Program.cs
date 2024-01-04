var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();

app.MapGet("/users", () => users);

app.MapGet("/users/{id}", (int id) => users.FirstOrDefault(x => x.Id == id));

app.MapPost("/users", (User user) => users.Add(user));

app.MapPut("/users/{id}", (User user, int id) => 
{
    int index = users.FindIndex(x => x.Id == id);

    users[index] = user;
});

app.MapDelete("/users/{id}", (int id) => {
    User user = users.FirstOrDefault(x => x.Id == id);
    users.Remove(user);
});

app.Run();

public class User
{
    public int Id {get;set;}

    public string? Name {get;set;} = "";

    public int Age {get; set;}
}