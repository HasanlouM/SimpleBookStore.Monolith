using BookStore.Domain.Catalog.Models.AuthorAggregate;

namespace BookStore.Domain.Catalog.Models.PublisherAggregate
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAll(CancellationToken cancellation = default);
        Task<Publisher?> Get(int id, CancellationToken cancellation = default);
        Task<Publisher> Add(Publisher model, CancellationToken cancellation = default);
    }
}
