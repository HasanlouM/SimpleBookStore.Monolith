using BookStore.Application.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using BookStore.Test.Share.TestDoubles;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class DefineBook : ITask<DefineBookCommand, BookQueryModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookStoreDbContext _dbContext;

    public DefineBook(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = UnitOfWorkFactory.Create(dbContext);
    }

    public async Task<BookQueryModel> Perform(DefineBookCommand command)
    {
        var repository = new BookRepository(_dbContext);
        var categoryRepository = new CategoryRepository(_dbContext);
        var authorRepository = new AuthorRepository(_dbContext);
        var publisherRepository = new PublisherRepository(_dbContext);
        var commandHandler = new DefineBookCommandHandler(
            _unitOfWork, repository, categoryRepository, authorRepository, publisherRepository, StubUtcClock.Default);

        return await commandHandler.HandleAsync(command, CancellationToken.None);
    }
}