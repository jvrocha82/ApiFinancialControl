using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiFinancialControl.Data.Dtos.OperationDto;

public class EntryOperationDto
{
    [Required(ErrorMessage = "Toda operação precisa estar vinculada a um Banco")]
    public int BankAccountId { get; set; }
    [Required(ErrorMessage = "O valor da operação não pode ser nullo")]
    public double Value { get; set; }
    [Required(ErrorMessage = "É preciso definir um tipo para a operação")]
    public string OperationType { get; set; }

}
