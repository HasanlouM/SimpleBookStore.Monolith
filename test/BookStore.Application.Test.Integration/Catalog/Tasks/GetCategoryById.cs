using BookStore.Application.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class GetCategoryById : ITask<int, CategoryQueryModel?>
{
    private readonly BookStoreDbContext _dbContext;

    public GetCategoryById(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<CategoryQueryModel?> Perform(int id)
    {
        var query = new GetCategoryByIdQuery { Id = id };
        var queryHandler = new GetCategoryByIdQueryHandler(_dbContext);
        return queryHandler.HandleAsync(query, CancellationToken.None);
    }
}