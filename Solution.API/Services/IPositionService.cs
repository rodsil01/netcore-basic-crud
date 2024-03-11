using Calculator.API.Resources;

namespace Calculator.API.Services;

public interface IPositionService {
    Task AddAsync(AddPositionResource position);
    Task<List<PositionResource>> GetAllAsync();
    Task<PositionResource?> GetByIdAsync(Guid positionId);
    Task Update(Guid positionId, UpdatePositionResource position);
    Task Remove(Guid positionId);
}
