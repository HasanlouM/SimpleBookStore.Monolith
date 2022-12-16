using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookStore.Persistence.EF
{
    public class BookStoreUnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext _dbContext;

        public BookStoreUnitOfWork(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChanges(CancellationToken cancellation = default)
        {
            return _dbContext.SaveChangesAsync(cancellation);
        }

        public Task<IDbContextTransaction> BeginTransaction(
            CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
