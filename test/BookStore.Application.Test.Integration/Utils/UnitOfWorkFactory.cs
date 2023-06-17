using BookStore.Persistence.EF;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Utils;

public class UnitOfWorkFactory
{
    private UnitOfWorkFactory()
    {
    }

    public static IUnitOfWork Create(BookStoreDbContext dbContext)
    {
        return new BookStoreUnitOfWork(dbContext);
    }
}