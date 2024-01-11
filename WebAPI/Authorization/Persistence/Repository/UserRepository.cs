namespace Persistence.Repository;

using Authorization.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Authorization.Application.DTOs;
using Authorization.Application.Interfaces.DTOs;
using Authorization.Domain;
using AutoMapper;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public bool IsUniqueUser(string login)
    {
        User user = _context.users.FirstOrDefault(x => x.Login == login);
        return user is not null ? true : false;
    }

    public Task<ResponseLoginDTO> Login(RequestLoginDTO requestLogin)
    {
        throw new InvalidOperationException();
    }

    public async Task<User> Registeration(RequestRegisterationDTO requestRegisteration)
    {
        MapperConfiguration mapperConfiguration = 
            new MapperConfiguration(x => x.CreateMap<User, RequestLoginDTO>());
            
        Mapper mapper = new Mapper(mapperConfiguration);

        User user = mapper.Map<User>(requestRegisteration);

        _context.users.AddAsync(user);
        _context.SaveChangesAsync();

        user.Password = "";
        
        return user;
    }
}