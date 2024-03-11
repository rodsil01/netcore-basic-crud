namespace Calculator.API.Domain.Repositories;

public interface IUnitOfWork {
    Task SaveChangesAsync();
}
