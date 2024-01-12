namespace Authorization.Application.DTOs.mappers;

using AutoMapper;
using Authorization.Domain;


public class LoginDTOProfile : Profile
{
    public LoginDTOProfile()
    {
        CreateMap<User, RequestLoginDTO>();
    }
}

public class RegisterationDTOProfile : Profile
{
    public RegisterationDTOProfile()
    {
        CreateMap<User, RequestRegisterationDTO>();
    }
}