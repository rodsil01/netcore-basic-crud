using Calculator.API.Resources;
using Calculator.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers;

[Route("api/positions")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService) 
    {
        _positionService = positionService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveAsync([FromBody] AddPositionResource resource)
    {
        try
        {
            await _positionService.AddAsync(resource);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var result = await _positionService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet("{positionId}")]
    public async Task<IActionResult> GetAllAsync(Guid positionId)
    {
        try
        {
            var result = await _positionService.GetByIdAsync(positionId);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPatch("{positionId}")]
    public async Task<IActionResult> UpdateAsync(Guid positionId, [FromBody] UpdatePositionResource resource)
    {
        try
        {
            await _positionService.Update(positionId, resource);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpDelete("{positionId}")]
    public async Task<IActionResult> DeleteAsync(Guid positionId)
    {
        try
        {
            await _positionService.Remove(positionId);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}