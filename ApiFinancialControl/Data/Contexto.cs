using ApiFinancialControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFinancialControl.Data;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {

    }
    public DbSet<Account> Account { get; set; }
    public DbSet<BankAccount> BankAccount { get; set; }
    public DbSet<Operation> Operation { get; set; }
    public DbSet<User> User { get; set; }
}
