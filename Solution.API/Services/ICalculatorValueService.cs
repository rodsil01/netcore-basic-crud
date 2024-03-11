using Calculator.API.Domain.Models;
using Calculator.API.Resources;

namespace Calculator.API.Services;

public interface ICalculatorValueService {
    Task<List<CalculatorValue>> SaveAsync(AddCalculatorValueResource calculatorValue);
}
