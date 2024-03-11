using Calculator.API.Domain.Models;

namespace Calculator.API.Domain.Repositories;

public interface IPositionRepository {
    Task AddAsync(Position position);
    Task<List<Position>> GetAllAsync();
    Task<Position?> GetByIdAsync(Guid positionId);
    void Update(Position position);
    void Remove(Position position);
}
