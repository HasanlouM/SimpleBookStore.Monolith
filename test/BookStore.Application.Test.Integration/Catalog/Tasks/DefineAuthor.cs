using BookStore.Application.Catalog.AuthorAggregate.Commands;
using BookStore.Application.Contract.Catalog.AuthorAggregate.Commands;
using BookStore.Application.Contract.Catalog.AuthorAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using BookStore.Test.Share.TestDoubles;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class DefineAuthor : ITask<DefineAuthorCommand, AuthorQueryModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookStoreDbContext _dbContext;

    public DefineAuthor(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = UnitOfWorkFactory.Create(dbContext);
    }

    public async Task<AuthorQueryModel> Perform(DefineAuthorCommand command)
    {
        var repository = new AuthorRepository(_dbContext);
        var commandHandler = new DefineAuthorCommandHandler(_unitOfWork, repository, StubUtcClock.Default);
        return await commandHandler.HandleAsync(command, CancellationToken.None);
    }
}