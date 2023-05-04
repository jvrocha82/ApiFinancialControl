using ApiFinancialControl.Data.Dtos.UserDto;
using ApiFinancialControl.Models;
using AutoMapper;

namespace ApiFinancialControl.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
}
