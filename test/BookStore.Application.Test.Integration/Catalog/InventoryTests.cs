using BookStore.Application.Contract.Catalog.InventoryAggregate.Commands;
using BookStore.Application.Test.Integration.Catalog.Tasks;
using BookStore.Application.Test.Integration.Utils;
using FluentAssertions;

namespace BookStore.Application.Test.Integration.Catalog
{
    public class InventoryTests : PersistTest
    {
        [Fact]
        public async Task Add_a_book_to_inventory()
        {
            var categoryCommand = DefineCategoryCommandFactory.Create();
            var category = await new DefineCategory(DbContext).Perform(categoryCommand);

            var authorCommand = DefineAuthorCommandFactory.Create(); ;
            var author = await new DefineAuthor(DbContext).Perform(authorCommand);

            var publisherCommand = DefinePublisherCommandBuilder.New().Build();
            var publisher = await new DefinePublisher(DbContext).Perform(publisherCommand);

            var defineBookCommand = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .WithAuthor(author.Id)
                .WithPublisher(publisher.Id)
                .Build();

            var book = await new DefineBook(DbContext).Perform(defineBookCommand);

            var addBookToInventoryCommand = new AddBookToInventoryCommand
            {
                BookId = book.Id,
                Quantity = 10,
                ReorderThreshold = 100
            };

            var actualInventory = await new AddBookToInventory(DbContext).Perform(addBookToInventoryCommand);

            actualInventory.Should().BeEquivalentTo(addBookToInventoryCommand);
        }
    }
}
