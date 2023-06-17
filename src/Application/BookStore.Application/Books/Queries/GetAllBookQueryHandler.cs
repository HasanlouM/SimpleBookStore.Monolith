using BookStore.Application.Contract.Books.Queries;
using BookStore.Domain.Models.Books;
using BookStore.Persistence.EF;
using Common.Application;
using Common.Application.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Application.Books.Queries;

public class GetAllBookQueryHandler :
    IQueryHandler<GetAllBookQuery, IEnumerable<BookQueryModel>?>
{
    private readonly BookStoreDbContext _dbContext;

    public GetAllBookQueryHandler(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BookQueryModel>?> HandleAsync(
        GetAllBookQuery query, CancellationToken cancellation = default)
    {
        var filter = CreateQueryFilters(query);
        var queryable = from book in _dbContext.Books.Where(filter)
                        join category in _dbContext.BookCategories
                            on book.CategoryId equals category.Id
                        select new BookQueryModel
                        {
                            Category = category.Name,
                            Id = book.Id,
                            Title = book.Title,
                            Publisher = book.Publisher,
                            Author = book.Author,
                            Isbn = book.Isbn,
                            Price = book.Price,
                            PublicationDate = book.PublicationDate,
                            Description = book.Description,
                            Image = Convert.ToBase64String(book.Image)
                        };

        var result = await queryable.ToListAsync(cancellation);

        return result;
    }

    private Expression<Func<Book, bool>> CreateQueryFilters(GetAllBookQuery query)
    {
        var exp = ExpressionBuilder.Create<Book>(b => !b.Deleted);

        if (query.CategoryId is > 0)
        {
            exp = exp.And(b => b.CategoryId.Equals(query.CategoryId));
        }

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            exp = exp.And(b => b.Title.Contains(query.Title));
        }

        if (!string.IsNullOrWhiteSpace(query.Author))
        {
            exp = exp.And(b => b.Author.Contains(query.Author));
        }

        if (!string.IsNullOrWhiteSpace(query.Publisher))
        {
            exp = exp.And(b => b.Publisher.Contains(query.Publisher));
        }

        if (query.PublicationDateFrom != default)
        {
            exp = exp.And(b => b.PublicationDate >= query.PublicationDateFrom);
        }

        if (query.PublicationDateTo != default)
        {
            exp = exp.And(b => b.PublicationDate <= query.PublicationDateTo);
        }

        if (query.PriceFrom is > 0)
        {
            exp = exp.And(b => b.Price >= query.PriceFrom);
        }

        if (query.PriceTo is > 0)
        {
            exp = exp.And(b => b.Price <= query.PriceTo);
        }

        return exp;
    }
}