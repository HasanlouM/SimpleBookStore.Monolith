using BookStore.Application.Catalog.BookAggregate.Queries;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class GetBookById : ITask<int, BookQueryModel?>
{
    private readonly BookStoreDbContext _dbContext;

    public GetBookById(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<BookQueryModel?> Perform(int id)
    {
        var query = new GetBookByIdQuery { Id = id };
        var queryHandler = new GetBookByIdQueryHandler(_dbContext);
        return queryHandler.HandleAsync(query, CancellationToken.None);
    }
}