namespace Authorization.Persistence.Repository;

using System.Text;

using Authorization.Application.Interfaces.Repository;
using Authorization.Application.DTOs;
using Authorization.Domain;
using Authorization.Application.DTOs.mappers;
using Authorization.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    private string _secretKey;
    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void SetSecretKey(string sectionName, string valueName, string path)
    {
        ConfigurationManageService configManage = new ConfigurationManageService();
        
        configManage.SetConfiguration(new ConfigurationEntity()
        {
            PathToFile = path,
            ValueName = valueName,
            SectionName = sectionName
        });

        _secretKey = configManage.Value;
    }
    
    public bool IsUniqueUser(string login)
    {
        User user = _context.users.FirstOrDefault(x => x.Login == login);
        return user is not null ? true : false;
    }

    public async Task<ResponseLoginDTO> Login(RequestLoginDTO requestLogin)
    {
        ResponseLoginDTO response;
        
        User user = await _context.users.FirstOrDefaultAsync(
            x => x.Login.ToLower() == requestLogin.Login.ToLower() && x.Password == requestLogin.Password);

        if (user == null)
        {
            response = new ResponseLoginDTO()
            {
                Token = "",
                User = null
            };
            return response;
        }
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] keyBytes = Encoding.ASCII.GetBytes(_secretKey);

        SecurityTokenDescriptor tokenDesctiptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name ,user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.Now.AddMinutes(3),
            SigningCredentials = new (new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDesctiptor);

        response = new ResponseLoginDTO()
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