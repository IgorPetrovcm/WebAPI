namespace Authorization.Application.DTOs;

using Authorization.Application.Interfaces.DTOs;


public class RequestRegisterationDTO : IUserRequestFeatures
{
    public string Login { get; set; }
    
    public string Password { get; set; }

    public string Role { get; set; } = "user";
}