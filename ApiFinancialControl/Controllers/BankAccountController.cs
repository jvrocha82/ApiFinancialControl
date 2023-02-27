using ApiFinancialControl.Data;
using ApiFinancialControl.Data.Dtos.BankAccountDto;
using ApiFinancialControl.Models;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinancialControl.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly Contexto _context;
    private IMapper _mapper;

    public BankAccountController(Contexto context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public CreatedAtActionResult CreateBankAccount([FromBody] CreateBankAccountDto BankAccountDto)
    {
        BankAccount bankAccount = _mapper.Map<BankAccount>(BankAccountDto);

        _context.BankAccount.Add(bankAccount);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(GetBankAccountById),
            new { id = bankAccount.Id },
            bankAccount);
    }
    [HttpGet("{id}")]
    public IActionResult GetBankAccountById(int id)
    {
        var bankAccount = _context.BankAccount
            .FirstOrDefault(bankAccount => bankAccount.Id == id);
        if (bankAccount == null) return NotFound();
        var bankAccountDto = _mapper.Map<ReadBankAccountDto>(bankAccount);

        return Ok(bankAccountDto);
    }
    [HttpGet]
    public IEnumerable<ReadBankAccountDto> GetBankAccount([FromQuery] int accountId, [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadBankAccountDto>>(_context.BankAccount.Where(bankAccount => bankAccount.AccountId == accountId).Skip(skip).Take(take));
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBankAccount(int id, [FromBody] UpdateBankAccountDto bankAccountDto)
    {
        var bankAccount = _context.BankAccount.FirstOrDefault(
            bankAccount => bankAccount.Id == id);
        if (bankAccount == null) return NotFound();
        _mapper.Map(bankAccountDto, bankAccount);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBankAccountDto(int id)
    {
        var bankAccount = _context.BankAccount.FirstOrDefault(
            bankAccount => bankAccount.Id == id);
        if (bankAccount == null) return NotFound();

        _context.Remove(bankAccount);
        _context.SaveChanges();
        return NoContent();
    }
}
