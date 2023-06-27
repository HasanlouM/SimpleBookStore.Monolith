using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;

namespace BookStore.Application.Test.Integration.Catalog;

internal static class DefineCategoryCommandFactory
{
    public static DefineCategoryCommand Create()
    {
        return new DefineCategoryCommand
        {
            Name = "test"
        };
    }
    public static DefineCategoryCommand Create(string name)
    {
        return new DefineCategoryCommand
        {
            Name = name
        };
    }
}