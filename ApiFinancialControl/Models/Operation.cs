using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Models;

public class Operation
{
    [Required(ErrorMessage = "O Id da Operação é obrigatório")]

    public int Id { get; set; }
   
    [ForeignKey("BankAccount")]
    [Required(ErrorMessage = "Toda operação precisa estar vinculada a um Banco")]
    public int BankAccountId { get; set; }
    [Required(ErrorMessage = "O valor da operação não pode ser nullo")]
    public double Value { get; set; }
    [Required(ErrorMessage = "É preciso definir um tipo para a operação")]
    public string OperationType { get; set; }
    public bool Reverted { get; set; }
}
