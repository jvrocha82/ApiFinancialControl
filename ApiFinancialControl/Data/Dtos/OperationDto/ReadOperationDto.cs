namespace ApiFinancialControl.Data.Dtos.OperationDto;

public class ReadOperationDto
{
    public int BankAccountId { get; set; }
    public double Value { get; set; }
    public string OperationType { get; set; }
}
