namespace Authorization.Application.Interfaces.DTOs;

public interface IUserRequestFeatures
{
    string Login { get; set; }
    
    string Password { get; set; }
}