namespace Authorization.Application.Interfaces.Repository;

using Authorization.Domain;


public interface IUserRepository
{
    Task CreateUser();

    Task<User> GetUser();
}