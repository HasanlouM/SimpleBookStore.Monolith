using BookStore.Application.Contract.Books.Queries;
using BookStore.Persistence.EF;
using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries
{
    public class GetBookCategoryByIdQueryHandler :
        IQueryHandler<GetBookCategoryByIdQuery, BookCategoryQueryModel?>
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookCategoryByIdQueryHandler(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookCategoryQueryModel?> HandleAsync(
            GetBookCategoryByIdQuery query, CancellationToken cancellation = default)
        {
            var category = await _dbContext.BookCategories.FirstOrDefaultAsync(c =>
                !c.Deleted && c.Id == query.Id, cancellation);

            if (category is null)
            {
                return null;
            }

            return new BookCategoryQueryModel
            {
                Id = category.Id,
                Title = category.Title
            };
        }
    }
}
