using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using Common.Application;
using Common.Domain.Utils;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.CategoryAggregate.Commands;

public class DefineCategoryCommandHandler
    : ICommandHandler<DefineCategoryCommand, CategoryQueryModel>
{
    private readonly IUnitOfWork _uow;
    private readonly ICategoryRepository _repository;
    private readonly IClock _clock;

    public DefineCategoryCommandHandler(
        IUnitOfWork uow,
        ICategoryRepository repository, IClock clock)
    {
        _uow = uow;
        _repository = repository;
        _clock = clock;
    }

    public async Task<CategoryQueryModel> HandleAsync(
        DefineCategoryCommand command, CancellationToken cancellation = default)
    {
        var model = new Category(command.Name, _clock);

        var category = await _repository.Add(model, cancellation);
        await _uow.SaveChanges(cancellation);

        return new CategoryQueryModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}