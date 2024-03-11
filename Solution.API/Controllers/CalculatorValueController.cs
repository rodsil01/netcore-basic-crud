using Calculator.API.Resources;
using Calculator.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers;

[Route("api/calculator")]
[ApiController]
public class CalculatorValueController : ControllerBase
{
    private readonly ICalculatorValueService _calculatorValueService;

    public CalculatorValueController(ICalculatorValueService calculatorValueService) 
    {
        _calculatorValueService = calculatorValueService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveAsync([FromBody] AddCalculatorValueResource value)
    {
        try
        {
            var result = await _calculatorValueService.SaveAsync(value);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}