using ApiFinancialControl.Data;
using ApiFinancialControl.Data.Dtos.AccountDto;
using ApiFinancialControl.Data.Dtos.UserDto;
using ApiFinancialControl.Models;
using ApiFinancialControl.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ApiFinancialControl.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly Contexto _context;
    private IMapper _mapper;

    public UserController(Contexto context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public CreatedAtActionResult CreateUser([FromBody] CreateUserDto userDto)
    {
        userDto.Password = EncryptService.EncryptPassword(userDto.Password);
        User user = _mapper.Map<User>(userDto);
        _context.User.Add(user);
        _context.SaveChanges();
        var userDtoReturn = _mapper.Map<ReadUserDto>(user);
        return CreatedAtAction(
            nameof(GetUserById),
            new { id = user.Id },
            userDtoReturn);
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetUserById(int id)
    {
        var user = _context.User
            .FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        var userDto = _mapper.Map<ReadUserDto>(user);

        return Ok(userDto);

    }

    [HttpGet]
    [Authorize]
    public IActionResult GetUser()
    {
        string userId = TokenService.GetIdFromToken(User);
        var user = _context.User
            .FirstOrDefault(user => user.Id == Convert.ToInt16(userId));
        if (user == null) return NotFound();
            var userDto = _mapper.Map<ReadUserDto>(user);

        return Ok(userDto);

}
}
