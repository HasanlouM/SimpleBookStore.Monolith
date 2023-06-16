using BookStore.Application.Contract.Books.Commands;
using BookStore.Application.Contract.Books.Queries;
using BookStore.Domain.Model;
using BookStore.Domain.Models.Books;
using Common.Application;
using Common.Persistence.EF;

namespace BookStore.Application.Books.Commands;

public class DefineBookCategoryCommandHandler
    : ICommandHandler<DefineBookCategoryCommand, BookCategoryQueryModel>
{
    private readonly IUnitOfWork _uow;
    private readonly IBookCategoryRepository _repository;

    public DefineBookCategoryCommandHandler(
        IUnitOfWork uow,
        IBookCategoryRepository repository)
    {
        _uow = uow;
        _repository = repository;
    }

    public async Task<BookCategoryQueryModel> HandleAsync(
        DefineBookCategoryCommand command, CancellationToken cancellation = default)
    {
        var model = new BookCategory(command.Title);

        var category = await _repository.Add(model, cancellation);
        await _uow.SaveChanges(cancellation);

        return new BookCategoryQueryModel
        {
            Id = category.Id,
            Title = category.Title
        };
    }
}