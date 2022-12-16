using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleFramework.Infrastructure.Persistence.EF;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransaction(
        CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}