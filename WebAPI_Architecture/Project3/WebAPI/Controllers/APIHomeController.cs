using Microsoft.AspNetCore.Mvc;
using Persistence.DataContext;
using Application.Repositories;
using Domain;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/Home/[action]")]
public class APIHomeController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IUserDbRepository _rep;

    public APIHomeController(ApplicationContext context, IUserDbRepository rep)
    {
        _context = context;

        _context.Database.EnsureCreated();

        _rep = rep;
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        Results.Ok();
        return await _rep.GetAllAsync();
    }

    [HttpGet]
    public async Task<User> GetUser([FromQuery]int id)
    {
        return await _rep.GetUserAsync(id);
    }

    [HttpPost]
    public async Task Add([FromBody]User user)
    {
        await _rep.AddUserAsync(user);
        await _rep.SaveChangesAsync();
    }

    [HttpPut]
    public async Task Update([FromBody]User user)
    {
        await _rep.UpdateUserAsync(user);
        await _rep.SaveChangesAsync();
        Results.NoContent();
    }

    [HttpDelete]
    public async Task Delete([FromBody] User user)
    {
        await _rep.RemoveUserAsync(user);
        await _rep.SaveChangesAsync();
        Results.NoContent();
    }
}