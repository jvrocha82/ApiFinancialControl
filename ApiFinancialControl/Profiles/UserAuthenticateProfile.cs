
using ApiFinancialControl.Models;
using AutoMapper;

namespace ApiFinancialControl.Profiles;

public class UserAuthenticateProfile : Profile
{
    public UserAuthenticateProfile()
    {
        CreateMap<UserAuthenticateProfile, User>();
     
    }
}
