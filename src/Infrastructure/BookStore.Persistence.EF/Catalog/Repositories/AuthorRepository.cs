using BookStore.Domain.Catalog.Models.AuthorAggregate;

namespace BookStore.Persistence.EF.Catalog.Repositories;

public class AuthorRepository : BaseRepository<Author, int>, IAuthorRepository
{
    private readonly BookStoreDbContext _dbContext;

    public AuthorRepository(BookStoreDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Author>> GetAll(CancellationToken cancellation = default)
    {
        return base.Get((bc) =>
            !bc.Deleted, cancellation: cancellation);
    }
}