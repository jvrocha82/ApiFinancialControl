using ApiFinancialControl.Data;
using ApiFinancialControl.Data.Dtos.AccountDto;
using ApiFinancialControl.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ApiFinancialControl.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController: ControllerBase
{
    private readonly Contexto _context;
    private IMapper _mapper;
    public AccountController(Contexto contexto,IMapper mapper)
    {
        _context = contexto;
        _mapper = mapper;
  
    }


    [HttpGet]
    public IEnumerable<ReadAccountDto> GetAccounnt([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadAccountDto>>(_context.Account.Skip(skip).Take(take));
    }

    [HttpPost]
    public CreatedAtActionResult CreateAccounnt([FromBody] CreateAccountDto accountDto)
    {
        Account account = _mapper.Map<Account>(accountDto);
       
        _context.Account.Add(account);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(getAccounntById),
            new { id = account.Id },
            account);
    }

    [HttpGet("{id}")]
    public IActionResult getAccounntById(int id)
    {
        var account = _context.Account
            .FirstOrDefault(account => account.Id == id);
        if (account == null) return NotFound();
       var accountDto = _mapper.Map<ReadAccountDto>(account);

        return Ok(accountDto);

    }

    [HttpPut("{id}")]
    public IActionResult updateAccount(int id, [FromBody] UpdateAccountDto accountDto)
    {
        var account = _context.Account.FirstOrDefault(
            account => account.Id == id);
        if (account == null) return NotFound();
        _mapper.Map(accountDto, account);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult UpdatePartialAccount(int id, 
        JsonPatchDocument<UpdateAccountDto> patch)
    {
        var account = _context.Account.FirstOrDefault(
            account => account.Id == id);
        if(account == null) return NotFound();
        
        var accountToUpdate = _mapper.Map<UpdateAccountDto>(account);
        patch.ApplyTo(accountToUpdate, ModelState);

        if(!TryValidateModel(accountToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(accountToUpdate, account);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAccount(int id)
    {
        var account = _context.Account.FirstOrDefault(
           account => account.Id == id);
        if (account == null) return NotFound();

        _context.Remove(account);
        _context.SaveChanges();
        return NoContent();
    }


}
