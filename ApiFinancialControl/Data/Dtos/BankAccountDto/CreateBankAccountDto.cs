using ApiFinancialControl.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiFinancialControl.Data.Dtos.BankAccountDto;

public class CreateBankAccountDto
{


    [Required(ErrorMessage = "Bank account name is required !")]
    public string Name { get; set; }

    public string Description { get; set; }

    public double Balance { get; set; }
    public int AccountId { get; set; }



}
