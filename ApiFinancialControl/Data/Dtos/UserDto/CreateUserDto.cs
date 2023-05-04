using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Data.Dtos.UserDto;

public class CreateUserDto
{
    [Required(ErrorMessage = "The Usename is required !")]

    public string Username { get; set; }


    [Required(ErrorMessage = "The password is required !")]
    public string Password { get; set; }

}
