using BookStore.Application.Catalog.BookAggregate.Commands;
using BookStore.Application.Catalog.BookAggregate.Queries;
using BookStore.Application.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Persistence.EF.Catalog.Repositories;
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
        public async Task define_a_book_category()
        {
            var category = await CreateCategory("test");

            // To make sure data fetch from database not from memory
            DbContext.DetachAllEntities();

            var actualCategory = await GetCategoryById(category.Id);

            actualCategory
                .Should()
                .BeEquivalentTo(category);
        }

        [Fact]
        public async Task define_a_book()
        {
            var category = await CreateCategory("test");

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .Build();

            var book = await CreateBook(command);

            // To make sure data fetch from database not from memory
            DbContext.DetachAllEntities();

            var actualBook = await GetBookById(book.Id);

            actualBook
                .Should()
                .BeEquivalentTo(book, a => a.Excluding(z => z.Category));
        }

        private async Task<BookQueryModel> CreateBook(DefineBookCommand command)
        {
            var repository = new BookRepository(DbContext);
            var commandHandler = new DefineBookCommandHandler(_unitOfWork, repository);
            var book = await commandHandler.HandleAsync(command, CancellationToken.None);
            return book;
        }

        //private async Task<Author> CreateAuthor()
        //{

        //}

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

        private Task<BookQueryModel?> GetBookById(int id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var queryHandler = new GetBookByIdQueryHandler(DbContext);
            return queryHandler.HandleAsync(query, CancellationToken.None);
        }
    }
}