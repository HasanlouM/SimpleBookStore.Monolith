using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Test.Share.TestDoubles;

namespace BookStore.Domain.Test.Unit.Catalog.TestUtilities;

internal class AuthorTestFactory
{
    public static Author CreateWithFullName(string firstName, string lastName)
    {
        return new Author(firstName, lastName, "", StubUtcClock.Default);
    }
    public static Author CreateDummy()
    {
        return new Author("firstName", "lastName", "", StubUtcClock.Default);
    }
}