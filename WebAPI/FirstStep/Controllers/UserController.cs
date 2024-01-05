namespace FirstStep.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstStep.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;

public class UserController : ControllerBase
{
    private readonly UserContext _context;

    public UserController(UserContext context)
    {
        _context = context;

        _context.Database.EnsureCreated();

        _context.Users.Add(new User{Name = "Igor", Age = 18});

        _context.SaveChanges();
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id) ;
        return user is not null ? Ok(user) : BadRequest();
    }
}
