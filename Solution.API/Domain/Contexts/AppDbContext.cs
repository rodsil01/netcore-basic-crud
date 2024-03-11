using Microsoft.EntityFrameworkCore;

using Calculator.API.Domain.Models;

namespace Calculator.API.Domain.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public AppDbContext() {}
    
    public DbSet<CalculatorValue> CalculatorValues { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Calculator;Integrated Security=True;Persist Security Info=False;Connect Timeout=300;TrustServerCertificate=True");
    }

    public void EnsureDatabaseCreated() 
    {
        Database.EnsureCreated();
    }
}
