using BookStore.Application.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF.Catalog.Repositories;
using Common.Persistence.EF;
using FluentAssertions;

namespace BookStore.Application.Test.Integration.Catalog
{
    public class CategoryTests : PersistTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryTests()
        {
            _unitOfWork = UnitOfWorkFactory.Create(DbContext);
        }

        [Fact]
        public async Task define_a_category()
        {
            var category = await CreateCategory("test");

            // To make sure data fetch from database not from memory
            DbContext.DetachAllEntities();

            var actualCategory = await GetCategoryById(category.Id);

            actualCategory
                .Should()
                .BeEquivalentTo(category);
        }
        private async Task<CategoryQueryModel> CreateCategory(
            string name)
        {
            var command = new DefineCategoryCommand
            {
                Name = name
            };
            var repository = new CategoryRepository(DbContext);
            var commandHandler = new DefineCategoryCommandHandler(_unitOfWork, repository);
            var category = await commandHandler.HandleAsync(command, CancellationToken.None);
            return category;
        }

        private Task<CategoryQueryModel?> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var queryHandler = new GetCategoryByIdQueryHandler(DbContext);
            return queryHandler.HandleAsync(query, CancellationToken.None);
        }
    }
}
