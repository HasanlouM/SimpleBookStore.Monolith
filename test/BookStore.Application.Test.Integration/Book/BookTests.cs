using BookStore.Application.Books.Commands;
using BookStore.Application.Books.Queries;
using BookStore.Application.Contract.Books.Commands;
using BookStore.Application.Contract.Books.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF.Repositories.Books;
using Common.Persistence.EF;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace BookStore.Application.Test.Integration.Book
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
            var category = await AddBookCategory("test");

            DbContext.DetachAllEntities();

            var actualCategory = await GetBookCategoryById(category.Id);

            actualCategory
                .Should()
                .BeEquivalentTo(category);
        }

        [Fact]
        public async Task define_a_book()
        {
            var category = await AddBookCategory("test");

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(category.Id)
                .Build();

            var repository = new BookRepository(DbContext);
            var commandHandler = new DefineBookCommandHandler(_unitOfWork, repository);
            var book = await commandHandler.HandleAsync(command, CancellationToken.None);

            DbContext.DetachAllEntities();

            var actualBook = await GetBookById(book.Id);

            actualBook
                .Should()
                .BeEquivalentTo(book, a => a.Excluding(z => z.Category));
        }

        private async Task<BookCategoryQueryModel> AddBookCategory(
            string name)
        {
            var command = new DefineBookCategoryCommand
            {
                Name = name
            };
            var repository = new BookCategoryRepository(DbContext);
            var commandHandler = new DefineBookCategoryCommandHandler(_unitOfWork, repository);
            var category = await commandHandler.HandleAsync(command, CancellationToken.None);
            return category;
        }

        private Task<BookCategoryQueryModel?> GetBookCategoryById(int id)
        {
            var query = new GetBookCategoryByIdQuery { Id = id };
            var queryHandler = new GetBookCategoryByIdQueryHandler(DbContext);
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