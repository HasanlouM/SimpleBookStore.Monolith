using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Domain.Test.Unit.Catalog.TestUtilities;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog
{
    public class AuthorTests
    {
        [Fact]
        public void Define_an_author()
        {
            var author = new Author("Moji", "Hasanlou", "Moji's bio");
            author.FirstName.Should().Be("Moji");
            author.LastName.Should().Be("Hasanlou");
            author.Bio.Should().Be("Moji's bio");
            author.Status.Should().Be(AuthorStatus.Active);
            author.CreatedAt.Should().NotBe(default);
        }

        [Theory]
        [InlineData("Neal", "")]
        [InlineData("", "Ford")]
        public void Can_not_define_an_author_without_first_and_last_name(string firstName, string lastName)
        {
            Action action = () => AuthorTestFactory.CreateWithFullName(firstName, lastName);

            action.Should().Throw<NotEmptyException>();
        }

        [Fact]
        public void Inactive_an_author()
        {
            var author = AuthorTestFactory.CreateDummy();
            author.Inactivate();

            author.Status.Should().Be(AuthorStatus.Inactive);
        }

        [Fact]
        public void Active_an_author()
        {
            var author = AuthorTestFactory.CreateDummy();
            author.Activate();

            author.Status.Should().Be(AuthorStatus.Active);
        }
    }
}
