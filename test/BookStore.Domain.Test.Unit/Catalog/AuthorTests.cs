using BookStore.Domain.Catalog.Models.AuthorAggregate;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog
{
    public class AuthorTests
    {
        [Fact]
        public void define_an_author()
        {
            var author = new Author("Moji", "Hasanlou", "Moji's bio");
            author.FirstName.Should().Be("Moji");
            author.LastName.Should().Be("Hasanlou");
            author.Bio.Should().Be("Moji's bio");
            author.Status.Should().Be(AuthorStatus.Active);
            author.CreatedAt.Should().NotBe(default);
        }

        [Fact]
        public void defining_an_author_with_wrong_params_should_throw_an_exception()
        {
            Action action = () => new Author("", "Hasanlou", "Moji's bio");

            action.Should().Throw<NotEmptyException>();
        }
    }
}
