using Calculator.API.Domain.Models;

namespace Calculator.API.Domain.Repositories;

public interface ICalculatorValueRepository {
    Task AddRangeAsync(List<CalculatorValue> calculatorValues);
}
