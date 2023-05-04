using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Models;

[Table("Users")]
public class User
{
    
    [Column("Id")]
    [Display(Name = "Id")]
    public int Id { get; set; }
    
    [Column("Username")]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Column("Password")]
    [Display(Name = "Password")]
    public string Password { get; set; }

}
