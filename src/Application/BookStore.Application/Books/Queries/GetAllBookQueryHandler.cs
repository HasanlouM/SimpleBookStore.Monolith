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

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            exp = exp.And(b => b.Name.Contains(query.Name));
        }

        if (!string.IsNullOrWhiteSpace(query.Author))
        {
            exp = exp.And(b => b.Author.Contains(query.Author));
        }

        if (query.PublishYearFrom is > 0)
        {
            exp = exp.And(b => b.PublishYear >= query.PublishYearFrom);
        }

        if (query.PublishYearTo is > 0)
        {
            exp = exp.And(b => b.PublishYear <= query.PublishYearTo);
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