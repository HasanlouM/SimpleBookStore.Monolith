using BookStore.Domain.Catalog.Models.PublisherAggregate;
using BookStore.Domain.Test.Unit.Catalog.TestUtilities;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog;

public class PublisherTests
{
    [Fact]
    public void Define_a_publisher()
    {
        // Fixture Setup
        var name = "ORielly";
        var address = "Address of ORielly";
        var phoneNumber = "+61 29 191 9777";
        var email = "support@oreilly.com";

        // Exercise
        var publisher = PublisherTestBuilder.New()
            .WithName(name)
            .WithAddress(address)
            .WithPhoneNumber(phoneNumber)
            .WithEmail(email)
            .Build();

        // Verification
        publisher.Name.Should().Be(name);
        publisher.Address.Should().Be(address);
        publisher.PhoneNumber.Should().Be(phoneNumber);
        publisher.Email.Should().Be(email);
        publisher.Status.Should().Be(PublisherStatus.Active);
        publisher.CreatedAt.Should().NotBe(default);
    }

    [Fact]
    public void Publisher_can_not_be_define_with_invalid_email()
    {
        Action action = () => PublisherTestBuilder.New().WithEmail("fake.com").Build();

        action.Should().Throw<InvalidParameterException>();
    }

    [Fact]
    public void Inactive_a_publisher()
    {
        var publisher = PublisherTestBuilder.New().Build();

        publisher.Inactivate();

        publisher.Status.Should().Be(PublisherStatus.Inactive);
    }

    [Fact]
    public void Active_a_publisher()
    {
        var publisher = PublisherTestBuilder.New().Build();

        publisher.Activate();

        publisher.Status.Should().Be(PublisherStatus.Active);
    }
}