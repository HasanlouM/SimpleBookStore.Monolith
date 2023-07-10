using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Domain.Catalog.Core;
using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Common.Application;
using Common.Application.Utils;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.BookAggregate.Commands
{
    public class DefineBookCommandHandler
        : ICommandHandler<DefineBookCommand, BookQueryModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public DefineBookCommandHandler(
            IUnitOfWork uow,
            IBookRepository repository,
            ICategoryRepository categoryRepository,
            IAuthorRepository authorRepository,
            IPublisherRepository publisherRepository)
        {
            _uow = uow;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<BookQueryModel> HandleAsync(
            DefineBookCommand command, CancellationToken cancellation = default)
        {
            await GuardAgainstInvalidCategoryId(command.CategoryId, cancellation);
            await GuardAgainstInvalidAuthorId(command.AuthorId, cancellation);
            await GuardAgainstInvalidPublisherId(command.PublisherId, cancellation);

            var model = new Book(command.CategoryId, command.Title, command.PublisherId, command.Isbn,
                command.AuthorId, command.Price, command.PublicationDate, command.Image?.ToByte() ?? null, command.Description);

            var book = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new BookQueryModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = "",
                Isbn = book.Isbn,
                Price = book.Price,
                PublicationDate = book.PublicationDate,
                Description = book.Description,
                Image = Convert.ToBase64String(book.Image)
            };
        }

        private async Task GuardAgainstInvalidCategoryId(int id, CancellationToken cancellation)
        {
            var isExistCategory = await _categoryRepository.Exists(id, cancellation);
            if (!isExistCategory)
            {
                throw new InvalidProgramException(Label.Book_Category);
            }
        }

        private async Task GuardAgainstInvalidAuthorId(int id, CancellationToken cancellation)
        {
            var isExist = await _authorRepository.Exists(id, cancellation);
            if (!isExist)
            {
                throw new InvalidProgramException(Label.Book_Author);
            }
        }

        private async Task GuardAgainstInvalidPublisherId(int id, CancellationToken cancellation)
        {
            var isExist = await _publisherRepository.Exists(id, cancellation);
            if (!isExist)
            {
                throw new InvalidProgramException(Label.Book_Publisher);
            }
        }
    }
}