namespace Authorization.Application.Interfaces.Repository;

using Authorization.Domain;
using Authorization.Application.DTOs;


public interface IUserRepository
{
    void SetSecretKey(string sectionName, string valueName, string path);
    bool IsUniqueUser(string login);

    Task<ResponseLoginDTO> Login(RequestLoginDTO requestLogin);

    Task<User> Registeration(RequestRegisterationDTO requestRegisteration);
}