using BookStore.Application.Contract.Catalog.AuthorAggregate.Commands;

namespace BookStore.Application.Test.Integration.Catalog;

internal static class DefineAuthorCommandFactory
{
    public static DefineAuthorCommand Create()
    {
        return new DefineAuthorCommand
        {
            FirstName = "name",
            LastName = "family"
        };
    }
    public static DefineAuthorCommand Create(string name, string lastName)
    {
        return new DefineAuthorCommand
        {
            FirstName = name,
            LastName = lastName
        };
    }
}