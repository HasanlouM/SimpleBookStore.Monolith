using BookStore.Domain.Catalog.Models.AuthorAggregate;

namespace BookStore.Domain.Test.Unit.Catalog.TestUtilities;

internal class AuthorTestFactory
{
    public static Author CreateWithFullName(string firstName, string lastName)
    {
        return new Author(firstName, lastName, "");
    }
    public static Author CreateDummy()
    {
        return new Author("firstName", "lastName", "");
    }
}