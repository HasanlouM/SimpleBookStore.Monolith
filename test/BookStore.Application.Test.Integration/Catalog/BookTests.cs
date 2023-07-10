using BookStore.Application.Test.Integration.Catalog.Tasks;
using BookStore.Application.Test.Integration.Catalog.Utils;
using BookStore.Application.Test.Integration.Utils;
using FluentAssertions;

namespace BookStore.Application.Test.Integration.Catalog
{
    public class BookTests : PersistTest
    {
        [Fact]
        public async Task Define_a_book()
        {
            var categoryCommand = DefineCategoryCommandFactory.Create();
            var category = await new DefineCategory(DbContext).Perform(categoryCommand);

            var authorCommand = DefineAuthorCommandFactory.Create(); ;
            var author = await new DefineAuthor(DbContext).Perform(authorCommand);

            var publisherCommand = DefinePublisherCommandBuilder.New().Build();
            var publisher = await new DefinePublisher(DbContext).Perform(publisherCommand);

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .WithAuthor(author.Id)
                .WithPublisher(publisher.Id)
                .Build();

            var book = await new DefineBook(DbContext).Perform(command);

            // To make sure data fetch from database not from memory
            DbContext.DetachAllEntities();

            var actualBook = await new GetBookById(DbContext).Perform(book.Id);

            actualBook.Should().NotBeNull();
            actualBook.Title.Should().Be(command.Title);
            actualBook.Isbn.Should().Be(command.Isbn);
            actualBook.Price.Should().Be(command.Price);
            actualBook.PublicationDate.Should().Be(command.PublicationDate);
            actualBook.Author.Should().Be(author.FullName);
            actualBook.Category.Should().Be(category.Name);
            actualBook.Publisher.Should().Be(publisher.Name);
        }

        [Fact]
        public async Task Define_a_book_with_invalid_category()
        {
            var authorCommand = DefineAuthorCommandFactory.Create(); ;
            var author = await new DefineAuthor(DbContext).Perform(authorCommand);

            var publisherCommand = DefinePublisherCommandBuilder.New().Build();
            var publisher = await new DefinePublisher(DbContext).Perform(publisherCommand);

            var undefinedCategoryId = int.MaxValue;

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(undefinedCategoryId)
                .WithAuthor(author.Id)
                .WithPublisher(publisher.Id)
                .Build();

            var func = () => new DefineBook(DbContext).Perform(command);

            DbContext.DetachAllEntities();

            await func.Should().ThrowAsync<InvalidProgramException>();
        }

        [Fact]
        public async Task Define_a_book_with_invalid_author()
        {
            var categoryCommand = DefineCategoryCommandFactory.Create();
            var category = await new DefineCategory(DbContext).Perform(categoryCommand);

            var publisherCommand = DefinePublisherCommandBuilder.New().Build();
            var publisher = await new DefinePublisher(DbContext).Perform(publisherCommand);

            var undefinedAuthorId = int.MaxValue;

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .WithAuthor(undefinedAuthorId)
                .WithPublisher(publisher.Id)
                .Build();

            var func = () => new DefineBook(DbContext).Perform(command);

            DbContext.DetachAllEntities();

            await func.Should().ThrowAsync<InvalidProgramException>();
        }

        [Fact]
        public async Task Define_a_book_with_invalid_publisher()
        {
            var categoryCommand = DefineCategoryCommandFactory.Create();
            var category = await new DefineCategory(DbContext).Perform(categoryCommand);

            var authorCommand = DefineAuthorCommandFactory.Create(); ;
            var author = await new DefineAuthor(DbContext).Perform(authorCommand);

            var undefinedPublisher = int.MaxValue;

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .WithAuthor(author.Id)
                .WithPublisher(undefinedPublisher)
                .Build();

            var func = () => new DefineBook(DbContext).Perform(command);

            DbContext.DetachAllEntities();

            await func.Should().ThrowAsync<InvalidProgramException>();
        }
    }
}