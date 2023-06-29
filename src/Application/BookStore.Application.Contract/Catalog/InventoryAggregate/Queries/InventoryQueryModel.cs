namespace BookStore.Application.Contract.Catalog.InventoryAggregate.Queries
{
    public class InventoryQueryModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int ReorderThreshold { get; set; }
    }
}
