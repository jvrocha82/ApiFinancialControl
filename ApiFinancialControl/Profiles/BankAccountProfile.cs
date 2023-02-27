using ApiFinancialControl.Data.Dtos.BankAccountDto;
using ApiFinancialControl.Models;
using AutoMapper;

namespace ApiFinancialControl.Profiles;

public class BankAccountProfile : Profile

{
    public BankAccountProfile()
    {
        CreateMap<CreateBankAccountDto, BankAccount>();
        CreateMap<BankAccount, ReadBankAccountDto>();
        CreateMap<BankAccount, UpdateBankAccountDto>();
        CreateMap<BankAccount, ReadBankAccountDto>();
    }

}
