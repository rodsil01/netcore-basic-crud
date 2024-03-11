using Calculator.API.Domain.Models;
using Calculator.API.Domain.Repositories;
using Calculator.API.Resources;

namespace Calculator.API.Services.Impl;

public class CalculatorValueService : ICalculatorValueService  {
    private readonly ICalculatorValueRepository _calculatorValueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CalculatorValueService(ICalculatorValueRepository calculatorValueRepository, IUnitOfWork unitOfWork) 
    {
        _calculatorValueRepository = calculatorValueRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CalculatorValue>> SaveAsync(AddCalculatorValueResource calculatorValue) {
        Guid groupId = Guid.NewGuid();
        DateTime createdDate = DateTime.Now;

        List<CalculatorValue> values = calculatorValue.Values.Select(value => new CalculatorValue
        {
            Id = Guid.NewGuid(),
            GroupId = groupId,
            Value = value,
            CreatedDate = createdDate
        }).ToList();

        try
        {
            await _calculatorValueRepository.AddRangeAsync(values);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception) 
        {
            return null;
        }

        return values;
    }
}
