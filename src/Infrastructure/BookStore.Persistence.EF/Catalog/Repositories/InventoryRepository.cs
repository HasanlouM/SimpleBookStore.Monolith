using BookStore.Domain.Catalog.Models.InventoryAggregate;

namespace BookStore.Persistence.EF.Catalog.Repositories
{
    public class InventoryRepository: BaseRepository<Inventory, int>, IInventoryRepository
    {
        public InventoryRepository(BookStoreDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Inventory>> GetAll(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
