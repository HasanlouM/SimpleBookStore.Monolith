using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Persistence.EF
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges(CancellationToken cancellation = default);
        Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
    }
}
