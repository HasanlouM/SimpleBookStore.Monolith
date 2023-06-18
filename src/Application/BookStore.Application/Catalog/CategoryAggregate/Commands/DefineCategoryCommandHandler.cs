using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using Common.Application;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.CategoryAggregate.Commands;

public class DefineCategoryCommandHandler
    : ICommandHandler<DefineCategoryCommand, CategoryQueryModel>
{
    private readonly IUnitOfWork _uow;
    private readonly ICategoryRepository _repository;

    public DefineCategoryCommandHandler(
        IUnitOfWork uow,
        ICategoryRepository repository)
    {
        _uow = uow;
        _repository = repository;
    }

    public async Task<CategoryQueryModel> HandleAsync(
        DefineCategoryCommand command, CancellationToken cancellation = default)
    {
        var model = new Category(command.Name);

        var category = await _repository.Add(model, cancellation);
        await _uow.SaveChanges(cancellation);

        return new CategoryQueryModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}