using Calculator.API.Domain.Repositories;
using Calculator.API.Domain.Models;
using Calculator.API.Domain.Contexts;

namespace Calculator.API.Repositories;

public class CalculatorValueRepository : BaseRepository, ICalculatorValueRepository  {
    public CalculatorValueRepository(AppDbContext context) : base(context) {}

    public async Task AddRangeAsync(List<CalculatorValue> calculatorValues) {
        await _context.CalculatorValues.AddRangeAsync(calculatorValues);
    }
}
