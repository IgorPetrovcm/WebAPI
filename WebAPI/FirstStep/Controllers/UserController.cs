namespace FirstStep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstStep.Models;
using System.ComponentModel;

[ApiController]
[Route("/[controllers]")]
public class UserController : ControllerBase
{
    private readonly UserContext _context;

    public UserController(UserContext context)
    {
        _context = context;

        _context.Database.EnsureCreated();

        _context.Users.Add(new User{Name = "Igor", Age = 18});
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }
}
