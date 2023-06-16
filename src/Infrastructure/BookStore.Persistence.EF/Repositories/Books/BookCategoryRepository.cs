using BookStore.Domain.Models.Books;

namespace BookStore.Persistence.EF.Repositories.Books;

public class BookCategoryRepository : BaseRepository<BookCategory, int>, IBookCategoryRepository
{
    private readonly BookStoreDbContext _dbContext;

    public BookCategoryRepository(BookStoreDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<BookCategory>> GetAll(CancellationToken cancellation = default)
    {
        return base.Get((bc) =>
            !bc.Deleted, cancellation: cancellation);
    }
}