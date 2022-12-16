using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleFramework.Infrastructure.Persistence.EF;

public class BaseUnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _dbContext;

    public BaseUnitOfWork(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IDbContextTransaction> BeginTransaction(
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}