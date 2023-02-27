using ApiFinancialControl.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Data.Dtos.AccountDto;

public class CreateAccountDto
{
    public string Name { get; set; }
}
