using BookStore.Application.Contract.Books.Queries;
using BookStore.Persistence.EF;
using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries;

public class GetBookByIdQueryHandler :
    IQueryHandler<GetBookByIdQuery, BookQueryModel?>
{
    private readonly BookStoreDbContext _dbContext;

    public GetBookByIdQueryHandler(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BookQueryModel?> HandleAsync(
        GetBookByIdQuery query, CancellationToken cancellation = default)
    {
        var queryable = from book in _dbContext.Books
                        join category in _dbContext.BookCategories
                            on book.CategoryId equals category.Id
                        where !book.Deleted && book.Id.Equals(query.Id)
                        select new BookQueryModel
                        {
                            Category = category.Title,
                            Id = book.Id,
                            Name = book.Name,
                            Code = book.Code,
                            Author = book.Author,
                            Isbn = book.Isbn,
                            Price = book.Price,
                            PublishYear = book.PublishYear,
                            Description = book.Description,
                            Image = Convert.ToBase64String(book.Image)
                        };

        return await queryable.FirstOrDefaultAsync(cancellation);
    }
}