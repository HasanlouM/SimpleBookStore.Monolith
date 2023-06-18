using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Persistence.EF;
using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Catalog.CategoryAggregate.Queries
{
    public class GetCategoryByIdQueryHandler :
        IQueryHandler<GetCategoryByIdQuery, CategoryQueryModel?>
    {
        private readonly BookStoreDbContext _dbContext;

        public GetCategoryByIdQueryHandler(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryQueryModel?> HandleAsync(
            GetCategoryByIdQuery query, CancellationToken cancellation = default)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c =>
                !c.Deleted && c.Id == query.Id, cancellation);

            if (category is null)
            {
                return null;
            }

            return new CategoryQueryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
