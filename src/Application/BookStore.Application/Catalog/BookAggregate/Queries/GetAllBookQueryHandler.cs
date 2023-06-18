using System.Linq.Expressions;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Persistence.EF;
using Common.Application;
using Common.Application.Utils;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Catalog.BookAggregate.Queries;

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
                        join category in _dbContext.Categories
                            on book.CategoryId equals category.Id
                        join author in _dbContext.Authors 
                            on book.AuthorId equals author.Id
                        join publisher in _dbContext.Publishers 
                            on book.PublisherId equals publisher.Id
                        select new BookQueryModel
                        {
                            Category = category.Name,
                            Id = book.Id,
                            Title = book.Title,
                            Publisher = publisher.Name,
                            Author = $"{author.FirstName} {author.LastName}",
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

        if (query.AuthorId.HasValue)
        {
            exp = exp.And(b => b.AuthorId.Equals(query.AuthorId));
        }

        if (query.PublisherId.HasValue)
        {
            exp = exp.And(b => b.PublisherId.Equals(query.PublisherId));
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