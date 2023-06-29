using BookStore.Application.Catalog.InventoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.InventoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.InventoryAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks;

internal class AddBookToInventory : ITask<AddBookToInventoryCommand, InventoryQueryModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookStoreDbContext _dbContext;

    public AddBookToInventory(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = UnitOfWorkFactory.Create(dbContext);
    }

    public async Task<InventoryQueryModel> Perform(AddBookToInventoryCommand command)
    {
        var repository = new InventoryRepository(_dbContext);
        var uow = UnitOfWorkFactory.Create(_dbContext);
        var commandHandler = new AddBookToInventoryCommandHandler(repository, uow);
        return await commandHandler.HandleAsync(command, CancellationToken.None);
    }
}