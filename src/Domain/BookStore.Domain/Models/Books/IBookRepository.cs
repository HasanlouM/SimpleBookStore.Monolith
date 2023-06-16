namespace BookStore.Domain.Models.Books
{
    public interface IBookRepository
    {
        Task<Book?> Get(int id, CancellationToken cancellation = default);
        Task<Book> Add(Book model, CancellationToken cancellation = default);
    }
}
