using ApiFinancialControl.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiFinancialControl.Data.Dtos.BankAccountDto
{
    public class ReadBankAccountDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Balance { get; set; }

    }
}
