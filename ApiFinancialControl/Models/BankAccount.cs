using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Models;

public class BankAccount
{
    [Required(ErrorMessage = "O Id da conta Bancária é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome da Conta Bancaria é  obrigatório")]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Balance { get; set; }
    [ForeignKey("Account")]
    public int AccountId { get; set; }
}
