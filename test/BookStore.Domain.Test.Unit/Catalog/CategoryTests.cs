using BookStore.Domain.Catalog.Models.CategoryAggregate;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog
{
    public class CategoryTests
    {

        [Fact]
        public void Can_not_define_a_category_without_name()
        {
            Action action = () => new Category("");

            action
                .Should()
                .Throw<NotEmptyException>();
        }

        [Fact]
        public void Inactive_a_category()
        {
            var category = new Category("Software");
            category.Inactivate();

            category.Status.Should().Be(CategoryStatus.Inactive);
        }

        [Fact]
        public void Active_a_category()
        {
            var category = new Category("Software");
            category.Activate();

            category.Status.Should().Be(CategoryStatus.Active);
        }
    }
}