using ApiFinancialControl.Data;
using ApiFinancialControl.Data.Dtos.AccountDto;
using ApiFinancialControl.Data.Dtos.AuthenticationDto;
using ApiFinancialControl.Data.Dtos.UserDto;
using ApiFinancialControl.Models;
using ApiFinancialControl.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinancialControl.Controllers;

[ApiController]
[Route("[controller]")]
public class Authentication : ControllerBase
{
    private readonly Contexto _context;
    private IMapper _mapper;

    public Authentication(Contexto contexto, IMapper mapper)
    {
        _context = contexto;
        _mapper = mapper;
    }
    [HttpPost]

    public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuthenticateDto userDto)
    {
        var passwordEncripted = EncryptService.EncryptPassword(userDto.Password);
        var user = _context.User
           .FirstOrDefault(user => user.Username == userDto.Username && user.Password == passwordEncripted);
        if (user == null) return NotFound(new {message = "Usuário ou senha inválidos"});

        var token = TokenService.GenerateToken(user);

        return new
        {
            user = _mapper.Map<ReadUserDto>(user),
            token = token,
        };
    }

}
