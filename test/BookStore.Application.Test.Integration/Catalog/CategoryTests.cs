using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Test.Integration.Catalog.Tasks;
using BookStore.Application.Test.Integration.Utils;
using FluentAssertions;

namespace BookStore.Application.Test.Integration.Catalog
{
    public class CategoryTests : PersistTest
    {
        [Fact]
        public async Task Define_a_category()
        {
            var command = DefineCategoryCommandFactory.Create();
            var category = await new DefineCategory(DbContext).Perform(command);

            // To make sure data fetch from database not from memory
            DbContext.DetachAllEntities();

            var actualCategory = await new GetCategoryById(DbContext).Perform(category.Id);

            actualCategory
                .Should()
                .BeEquivalentTo(category);
        }
    }
}
