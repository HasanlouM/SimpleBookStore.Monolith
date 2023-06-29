using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Catalog.Models.InventoryAggregate
{
    public class Inventory : AggregateRoot<int>
    {
        private Inventory() { }

        public Inventory(int bookId, int quantity, int reorderThreshold)
        {
            Guard.NotNullOrDefault(bookId, Label.Inventory_BookId);
            Guard.NotNullOrDefault(quantity, Label.Inventory_Quantity);
            Guard.NotNullOrDefault(reorderThreshold, Label.Inventory_ReorderThreshold);

            BookId = bookId;
            Quantity = quantity;
            ReorderThreshold = reorderThreshold;
            CreatedAt = DateTime.UtcNow;
        }

        public int BookId { get; private set; }
        public int Quantity { get; private set; }
        public int ReorderThreshold { get; private set; }
    }
}
