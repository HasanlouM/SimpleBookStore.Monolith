using BookStore.Domain.Catalog.Models.CategoryAggregate;

namespace BookStore.Persistence.EF.Catalog.Repositories;

public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
{
    private readonly BookStoreDbContext _dbContext;

    public CategoryRepository(BookStoreDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Category>> GetAll(CancellationToken cancellation = default)
    {
        return base.Get((bc) =>
            !bc.Deleted, cancellation: cancellation);
    }
}