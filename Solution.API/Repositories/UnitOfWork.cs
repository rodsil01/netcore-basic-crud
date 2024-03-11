using Calculator.API.Domain.Repositories;
using Calculator.API.Domain.Contexts;

namespace Calculator.API.Repositories;

public class UnitOfWork : BaseRepository, IUnitOfWork  {
    public UnitOfWork(AppDbContext context) : base(context) {}

    public async Task SaveChangesAsync() {
        await _context.SaveChangesAsync();
    }
}
