namespace BookStore.Domain.Catalog.Models.InventoryAggregate
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAll(CancellationToken cancellation = default);
        Task<Inventory?> Get(int id, CancellationToken cancellation = default);
        Task<Inventory> Add(Inventory model, CancellationToken cancellation = default);
    }
}
