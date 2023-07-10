using BookStore.Application.Contract.Catalog.InventoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.InventoryAggregate.Queries;
using BookStore.Domain.Catalog.Models.InventoryAggregate;
using Common.Application;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.InventoryAggregate.Commands
{
    public class AddBookToInventoryCommandHandler : ICommandHandler<AddBookToInventoryCommand, InventoryQueryModel>
    {
        private readonly IInventoryRepository _repository;
        private readonly IUnitOfWork _uow;

        public AddBookToInventoryCommandHandler(
            IInventoryRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<InventoryQueryModel> HandleAsync(
            AddBookToInventoryCommand command, CancellationToken cancellation = default)
        {
            var model = new Inventory(command.BookId, command.Quantity, command.ReorderThreshold);

            var definedInventory = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new InventoryQueryModel
            {
                Id = definedInventory.Id,
                BookId = definedInventory.BookId,
                Quantity = definedInventory.Quantity,
                ReorderThreshold = definedInventory.ReorderThreshold
            };
        }
    }
}
