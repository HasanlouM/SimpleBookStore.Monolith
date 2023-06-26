using BookStore.Application.Catalog.BookAggregate.Commands;
using BookStore.Application.Catalog.BookAggregate.Queries;
using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
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
        public async Task define_a_book()
        {
            //var category = await CreateCategory("test");

            var command = DefineBookCommandBuilder
                .New()
                .WithCategory(1)
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


        private Task<BookQueryModel?> GetBookById(int id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var queryHandler = new GetBookByIdQueryHandler(DbContext);
            return queryHandler.HandleAsync(query, CancellationToken.None);
        }
    }
}