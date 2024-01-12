namespace Authorization.Application.DTOs.mappers;

using AutoMapper;
using Authorization.Domain;


public class LoginDTOProfile : Profile
{
    public LoginDTOProfile()
    {
        CreateMap<RequestLoginDTO, User>();
    }
}

public class RegisterationDTOProfile : Profile
{
    public RegisterationDTOProfile()
    {
        CreateMap<RequestRegisterationDTO, User>();
    }
}