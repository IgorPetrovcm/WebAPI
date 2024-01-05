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

    [HttpGet]
    public IActionResult GetUser([FromQuery]User user)
    {
        return user is not null ? Ok(user) : UnprocessableEntity();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody]User user)
    {
        if (user != null)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created($"User/GetById/{user.Id}",user);
        }
        else 
            return BadRequest();
    }
}
