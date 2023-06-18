using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog;

public class PublisherTests
{
    [Fact]
    public void define_a_publisher()
    {
        var publisher = new Publisher("Oriely", "Address", "123456", "oriely@gmail.com");
        publisher.Name.Should().Be("Oriely");
        publisher.Address.Should().Be("Address");
        publisher.PhoneNumber.Should().Be("123456");
        publisher.Email.Should().Be("oriely@gmail.com");
        publisher.Status.Should().Be(PublisherStatus.Active);
        publisher.CreatedAt.Should().NotBe(default);
    }

    [Fact]
    public void defining_a_publisher_with_invalid_email_should_throw_an_exception()
    {
        Action action = () => new Publisher("Oriely", "Address", "123456", "oriely@gmail");

        action.Should().Throw<InvalidParameterException>();
    }
}