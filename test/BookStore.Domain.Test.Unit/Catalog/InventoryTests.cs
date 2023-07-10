using BookStore.Domain.Catalog.Models.InventoryAggregate;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog
{
    public class InventoryTests
    {
        [Fact]
        public void Add_a_book_to_inventory()
        {
            var bookId = 1;
            var quantity = 100;
            var reorderThreshold = 10;
            var inventory = new Inventory(bookId, quantity, reorderThreshold);

            inventory.Should().NotBeNull();
            inventory.BookId.Should().Be(1);
            inventory.Quantity.Should().Be(100);
            inventory.ReorderThreshold.Should().Be(10);
        }

        [Theory]
        [InlineData(0, 10, 100)]
        [InlineData(1, 0, 100)]
        [InlineData(1, 10, 0)]
        public void Add_a_book_to_inventory_with_invalid_parameters(
            int bookId, int quantity, int reorderThreshold)
        {
            var action = () => new Inventory(bookId, quantity, reorderThreshold);

            action.Should().Throw<NotNullException>();
        }
    }
}
