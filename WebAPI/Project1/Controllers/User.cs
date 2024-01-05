namespace Project1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project1.Models;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly  UserContext _context;

    public UserController(UserContext context)
    {
        _context = context;

        _context.Database.EnsureCreated();

        _context.Users.Add(new User{Name = "Igor", Age = 17});
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }
}