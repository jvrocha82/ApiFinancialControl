using ApiFinancialControl.Data;
using ApiFinancialControl.Data.Dtos.AccountDto;
using ApiFinancialControl.Data.Dtos.BankAccountDto;
using ApiFinancialControl.Data.Dtos.OperationDto;
using ApiFinancialControl.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ApiFinancialControl.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationController : ControllerBase
{
    private readonly Contexto _context;
    private IMapper _mapper;

    public OperationController(Contexto context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("/Deposito")]
    public IActionResult EntryOperation([FromBody] EntryOperationDto operationDto)
    {
        var bankAccount = _context.BankAccount
               .FirstOrDefault(bankAccount => bankAccount.Id == operationDto.BankAccountId);
        if (bankAccount == null) return NotFound();
        if (operationDto.OperationType == "deposit")
        {
            bankAccount.Balance = bankAccount.Balance + operationDto.Value;
        }
        else if(operationDto.OperationType == "withdraw") 
        {
            if (bankAccount.Balance >= operationDto.Value)
            {
                bankAccount.Balance = bankAccount.Balance - operationDto.Value;
            }
        }
        else
        {
            return NotFound();
        }
        Operation operation = _mapper.Map<Operation>(operationDto);
        _context.Operation.Add(operation);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpGet]
    public IEnumerable<ReadOperationDto> GetOperation([FromQuery] int bankAccountId, [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadOperationDto>>(_context.Operation.Where(operation => operation.BankAccountId == bankAccountId).Skip(skip).Take(take));
    }
}
