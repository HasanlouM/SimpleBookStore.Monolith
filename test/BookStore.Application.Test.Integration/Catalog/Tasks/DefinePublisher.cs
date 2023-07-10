using BookStore.Application.Catalog.PublisherAggregate.Commands;
using BookStore.Application.Contract.Catalog.PublisherAggregate.Commands;
using BookStore.Application.Contract.Catalog.PublisherAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using BookStore.Test.Share.TestDoubles;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class DefinePublisher : ITask<DefinePublisherCommand, PublisherQueryModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookStoreDbContext _dbContext;

    public DefinePublisher(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = UnitOfWorkFactory.Create(dbContext);
    }

    public async Task<PublisherQueryModel> Perform(DefinePublisherCommand command)
    {
        var repository = new PublisherRepository(_dbContext);
        var commandHandler = new DefinePublisherCommandHandler(_unitOfWork, repository, StubUtcClock.Default);
        return await commandHandler.HandleAsync(command, CancellationToken.None);
    }
}