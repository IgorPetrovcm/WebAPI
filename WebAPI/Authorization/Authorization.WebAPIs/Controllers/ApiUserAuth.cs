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
[Route("api/UserAuth")]
public class ApiUserAuth : ControllerBase
{
    private IUserRepository _rep;
    
    public ApiUserAuth(UserRepository rep, ConfigurationManageService config)
    {
        _rep = rep;
        _rep._secrep
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]RequestLoginDTO userRequest)
    {
        ResponseLoginDTO response = await _rep.Login(userRequest);

        if (response.User == null || response.Token == "")
            return BadRequest(new { message = "This user not found " });

        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody]RequestRegisterationDTO userRequest)
    {
        if (_rep.IsUniqueUser(userRequest.Login))
        {
            return Ok(await _rep.Registeration(userRequest));
        }

        return BadRequest(new { message = "Login is not unique" });
    }
}