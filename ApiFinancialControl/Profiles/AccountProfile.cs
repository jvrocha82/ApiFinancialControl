using ApiFinancialControl.Data.Dtos.AccountDto;
using ApiFinancialControl.Models;
using AutoMapper;

namespace ApiFinancialControl.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountDto, Account>();
        CreateMap<UpdateAccountDto, Account>();
        CreateMap<Account, UpdateAccountDto>();
        CreateMap<Account, ReadAccountDto>();
    } 
}
