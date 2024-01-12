namespace Persistence.Repository;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Authorization.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Authorization.Application.DTOs;
using Authorization.Domain;
using AutoMapper;
using Authorization.Application.DTOs.mappers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    private string _secretKey;
    public UserRepository(ApplicationContext context, string secretKey)
    {
        _context = context;
        _secretKey = secretKey;
    }
    
    public bool IsUniqueUser(string login)
    {
        User user = _context.users.FirstOrDefault(x => x.Login == login);
        return user is not null ? true : false;
    }

    public async Task<ResponseLoginDTO> Login(RequestLoginDTO requestLogin)
    {
        User user = await _context.users.FirstOrDefaultAsync(
            x => x.Login.ToLower() == requestLogin.Login.ToLower() && x.Password == requestLogin.Password);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] keyBytes = Encoding.ASCII.GetBytes(_secretKey);

        SecurityTokenDescriptor tokenDesctiptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name ,user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.Now.AddDays(3),
            SigningCredentials = new (new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDesctiptor);

        ResponseLoginDTO response = new ResponseLoginDTO()
        {
            Token = tokenHandler.WriteToken(token),
            User = user
        };

        return response;
    }

    public async Task<User> Registeration(RequestRegisterationDTO requestRegisteration)
    {
        MapperConfiguration mapperConfiguration = 
            new MapperConfiguration(x => x.AddProfile<RegisterationDTOProfile>());
            
        Mapper mapper = new Mapper(mapperConfiguration);

        User user = mapper.Map<User>(requestRegisteration);

        _context.users.AddAsync(user);
        _context.SaveChangesAsync();

        user.Password = "";
        
        return user;
    }
}