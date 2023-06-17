using BookStore.Application.Contract.Books.Commands;
using BookStore.Application.Contract.Books.Queries;
using BookStore.Domain.Models.Books;
using Common.Application;
using Common.Application.Utils;
using Common.Persistence.EF;

namespace BookStore.Application.Books.Commands
{
    public class DefineBookCommandHandler
        : ICommandHandler<DefineBookCommand, BookQueryModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookRepository _repository;

        public DefineBookCommandHandler(
            IUnitOfWork uow,
            IBookRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<BookQueryModel> HandleAsync(
            DefineBookCommand command, CancellationToken cancellation = default)
        {
            var model = new Book(command.CategoryId, command.Title, command.Publisher, command.Isbn,
                command.Author, command.Price, command.PublicationDate, command.Image?.ToByte()?? null, command.Description);

            var book = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new BookQueryModel
            {
                Id = book.Id,
                Title = book.Title,
                Publisher = book.Publisher,
                Author = book.Author,
                Isbn = book.Isbn,
                Price = book.Price,
                PublicationDate = book.PublicationDate,
                Description = book.Description,
                Image = Convert.ToBase64String(book.Image)
            };
        }
    }
}
