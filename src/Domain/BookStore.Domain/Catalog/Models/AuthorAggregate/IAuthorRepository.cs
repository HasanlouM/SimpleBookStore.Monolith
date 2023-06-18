namespace BookStore.Domain.Catalog.Models.AuthorAggregate
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll(CancellationToken cancellation = default);
        Task<Author?> Get(int id, CancellationToken cancellation = default);
        Task<Author> Add(Author model, CancellationToken cancellation = default);
    }
}
