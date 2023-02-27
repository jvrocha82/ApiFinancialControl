
using ApiFinancialControl.Data.Dtos.OperationDto;
using ApiFinancialControl.Models;
using AutoMapper;

namespace ApiFinancialControl.Profiles;

public class OperationProfile : Profile
{
    public OperationProfile()
    {
        CreateMap<EntryOperationDto, Operation>();
        CreateMap<ReadOperationDto, Operation>();
        CreateMap<Operation, ReadOperationDto>();


    }
}
