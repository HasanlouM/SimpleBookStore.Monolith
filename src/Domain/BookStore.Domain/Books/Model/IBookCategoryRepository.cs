namespace BookStore.Domain.Books.Model;

public interface IBookCategoryRepository
{
    Task<IEnumerable<BookCategory>> GetAll(CancellationToken cancellation = default);
    Task<BookCategory?> Get(int id, CancellationToken cancellation = default);
    Task<BookCategory> Add(BookCategory model, CancellationToken cancellation = default);
}