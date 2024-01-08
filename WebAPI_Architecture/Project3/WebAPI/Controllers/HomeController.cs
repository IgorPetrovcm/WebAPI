using Microsoft.AspNetCore.Mvc;
using Persistence.DataContext;
using Persistence.Repositories;
using Domain;
using Application.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("Home/[action]")]
public class HomeController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IUserDbRepository _rep;

    public HomeController(ApplicationContext context, IUserDbRepository rep)
    {
        _context = context;

        _context.Database.EnsureCreated();

        _rep = rep;
    }

    [HttpGet]
    public async Task<List<User>> Index()
    {
        return await _rep.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<User> Index(int id)
    {
        return await _rep.GetUserAsync(id);
    }

    [HttpPost]
    public async Task Index([FromBody]User user)
    {
        await _rep.AddUserAsync(user);
        await _rep.SaveChangesAsync();
    }
}