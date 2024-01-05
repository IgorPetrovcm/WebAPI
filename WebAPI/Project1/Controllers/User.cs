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
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Created("api/user",user);
    }
}