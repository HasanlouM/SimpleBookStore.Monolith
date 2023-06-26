using BookStore.Application.Contract.Catalog.PublisherAggregate.Commands;
using BookStore.Application.Contract.Catalog.PublisherAggregate.Queries;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Common.Application;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.PublisherAggregate.Commands
{
    public class DefinePublisherCommandHandler
        : ICommandHandler<DefinePublisherCommand, PublisherQueryModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPublisherRepository _repository;

        public DefinePublisherCommandHandler(
            IUnitOfWork uow, IPublisherRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<PublisherQueryModel> HandleAsync(
            DefinePublisherCommand command, CancellationToken cancellation = default)
        {
            var model = new Publisher(command.Name, command.Address, command.PhoneNumber, command.Email);
            var definedPublisher = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new PublisherQueryModel
            {
                Id = definedPublisher.Id,
                Name = definedPublisher.Name,
                Address = definedPublisher.Address,
                PhoneNumber = definedPublisher.PhoneNumber,
                Email = definedPublisher.Email
            };
        }
    }
}
