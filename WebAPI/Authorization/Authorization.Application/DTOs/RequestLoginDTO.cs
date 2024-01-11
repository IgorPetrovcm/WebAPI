namespace Authorization.Application.DTOs;

using Authorization.Application.Interfaces.DTOs;


public class RequestLoginDTO : IUserRequest
{
    public string Login { get; set; }
    
    public string Password { get; set; }
}