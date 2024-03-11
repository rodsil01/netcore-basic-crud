using Calculator.API.Domain.Contexts;

namespace Calculator.API.Repositories;

public abstract class BaseRepository {
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) {
        this._context = context;
    }
}
