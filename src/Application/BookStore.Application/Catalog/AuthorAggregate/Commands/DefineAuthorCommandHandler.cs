using BookStore.Application.Contract.Catalog.AuthorAggregate.Commands;
using BookStore.Application.Contract.Catalog.AuthorAggregate.Queries;
using BookStore.Domain.Catalog.Models.AuthorAggregate;
using Common.Application;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.AuthorAggregate.Commands
{
    public class DefineAuthorCommandHandler
        : ICommandHandler<DefineAuthorCommand, AuthorQueryModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuthorRepository _repository;

        public DefineAuthorCommandHandler(
            IUnitOfWork uow,
            IAuthorRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<AuthorQueryModel> HandleAsync(
            DefineAuthorCommand command, CancellationToken cancellation = default)
        {
            var model = new Author(command.FirstName, command.LastName, command.Bio);
            var definedAuthor = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new AuthorQueryModel
            {
                Id = definedAuthor.Id,
                FirstName = definedAuthor.FirstName,
                LastName = definedAuthor.LastName,
                FullName = definedAuthor.FullName,
                Bio = definedAuthor.Bio
            };
        }
    }
}
