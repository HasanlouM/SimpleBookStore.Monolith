using BookStore.Domain.Catalog.Models.PublisherAggregate;

namespace BookStore.Persistence.EF.Catalog.Repositories;

public class PublisherRepository : BaseRepository<Publisher, int>, IPublisherRepository
{
    private readonly BookStoreDbContext _dbContext;

    public PublisherRepository(BookStoreDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Publisher>> GetAll(CancellationToken cancellation = default)
    {
        return base.Get((bc) =>
            !bc.Deleted, cancellation: cancellation);
    }
}