using BookStore.Application.Contract.Catalog.AuthorAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.PublisherAggregate.Commands;
using BookStore.Application.Test.Integration.Catalog.Tasks;
using BookStore.Application.Test.Integration.Utils;
using Common.Persistence.EF;
using FluentAssertions;

namespace BookStore.Application.Test.Integration.Catalog
{
    public class BookTests : PersistTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookTests()
        {
            _unitOfWork = UnitOfWorkFactory.Create(DbContext);
        }

        [Fact]
        public async Task define_a_book()
        {
            var categoryCommand = new DefineCategoryCommand
            {
                Name = "test"
            };
            var category = await new DefineCategory(DbContext).Perform(categoryCommand);

            var authorCommand = new DefineAuthorCommand
            {
                FirstName = "name",
                LastName = "family"
            };
            var author = await new DefineAuthor(DbContext).Perform(authorCommand);

            var publisherCommand = new DefinePublisherCommand
            {
                Name = "name",
                Address = "family",
                PhoneNumber = "09355082980",
                Email = "publisher@gmail.com",
            };
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
        }
    }
}