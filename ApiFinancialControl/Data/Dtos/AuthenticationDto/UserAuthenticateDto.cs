using System.ComponentModel.DataAnnotations;

namespace ApiFinancialControl.Data.Dtos.AuthenticationDto;

public class UserAuthenticateDto
{
    [Required(ErrorMessage = "The Usename is required !")]

    public string Username { get; set; }


    [Required(ErrorMessage = "The password is required !")]
    public string Password { get; set; }
}
