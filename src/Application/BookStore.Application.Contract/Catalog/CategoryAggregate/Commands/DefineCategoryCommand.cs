using Common.Application;
using FluentValidation;

namespace BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;

public class DefineCategoryCommand : ICommand
{
    public string Name { get; set; }
}

public class DefineBookCategoryCommandValidator
    : AbstractValidator<DefineCategoryCommand>
{
    public DefineBookCategoryCommandValidator()
    {
        RuleFor(cmd => cmd.Name)
            .NotEmpty();
    }
}