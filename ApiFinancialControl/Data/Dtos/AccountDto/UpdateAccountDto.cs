using ApiFinancialControl.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Data.Dtos.AccountDto;

public class UpdateAccountDto
{
 
    public string Name { get; set; }
}
