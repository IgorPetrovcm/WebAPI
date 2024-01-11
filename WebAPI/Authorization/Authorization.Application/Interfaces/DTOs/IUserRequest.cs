namespace Authorization.Application.Interfaces.DTOs;

public interface IUserRequest
{
    string Login { get; set; }
    
    string Password { get; set; }
}