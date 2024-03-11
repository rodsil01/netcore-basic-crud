using Calculator.API.Domain.Repositories;
using Calculator.API.Domain.Models;
using Calculator.API.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Calculator.API.Repositories;

public class PositionRepository : BaseRepository, IPositionRepository  {
    public PositionRepository(AppDbContext context) : base(context) {}

    public async Task AddAsync(Position position) {
        await _context.Positions.AddAsync(position);
    }

    public async Task<List<Position>> GetAllAsync() {
        return await _context.Positions.ToListAsync();
    }

    public async Task<Position?> GetByIdAsync(Guid positionId) {
        return await _context.Positions.FirstOrDefaultAsync(p => p.Id == positionId);
    }

    public void Update(Position position) {
        _context.Positions.Update(position).Property(p => p.GenId).IsModified = false;
    }

    public void Remove(Position position) {
        _context.Positions.Remove(position);
    }
}
