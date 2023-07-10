using BookStore.Domain.Catalog.Models.PublisherAggregate;
using BookStore.Test.Share.TestDoubles;

namespace BookStore.Domain.Test.Unit.Catalog.TestUtilities;

internal class PublisherTestBuilder
{
    private string _name = "test publisher";
    private string _address = "test address";
    private string _phoneNumber = "123456789";
    private string _email = "test@gmail.com";

    private PublisherTestBuilder() { }

    public static PublisherTestBuilder New()
    {
        return new PublisherTestBuilder();
    }

    public PublisherTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PublisherTestBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public PublisherTestBuilder WithPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }

    public PublisherTestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public Publisher Build()
    {
        return new Publisher(_name, _address, _phoneNumber, _email, StubUtcClock.Default);
    }
}