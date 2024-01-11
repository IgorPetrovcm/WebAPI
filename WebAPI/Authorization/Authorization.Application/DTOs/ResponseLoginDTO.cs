namespace Authorization.Application.DTOs;

using Authorization.Domain;


public class ResponseLoginDTO
{
    public User User { get; set; }
    
    public string Token { get; set; }
}