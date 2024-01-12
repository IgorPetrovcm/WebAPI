using Authorization.Application.Interfaces.DTOs;

namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Authorization.Application.Interfaces.Services; 
using Authorization.Application.Interfaces.Repository;
using Authorization.Application.DTOs;
using Authorization.Persistence;
using Authorization.Persistence.Repository;
using Authorization.Infrastructure.Services;


[ApiController]
[Route("api/UserAuth/[action]")]
public class ApiUserAuth : ControllerBase
{
    private readonly IUserRepository _rep;

    private readonly ApplicationContext _context;
    
    public ApiUserAuth(IUserRepository rep, ApplicationContext context)
    {
        rep.SetSecretKey("ApiSettings","SecretKey",
            "C:\\Users\\igorp\\Programming\\WebAPI\\WebAPI\\Authorization\\Authorization.WebAPIs\\appsettings.json");
        
        _rep = rep;

        _context = context;

        _context.Database.EnsureCreated();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody]RequestLoginDTO userRequest)
    {
        ResponseLoginDTO response = await _rep.Login(userRequest);

        if (response.User == null || response.Token == "")
            return BadRequest(new { message = "This user not found " });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RequestRegisterationDTO userRequest)
    {
        if (!_rep.IsUniqueUser(userRequest.Login))
        {
            return Ok(await _rep.Registeration(userRequest));
        }
        else
            return BadRequest(new { message = "Login is not unique" });
    }
}