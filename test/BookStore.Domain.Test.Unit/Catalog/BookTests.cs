using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using Common.Domain.Core.Exceptions;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog
{
    public class BookTests
    {
        [Fact]
        public void Define_a_book_properly()
        {
            var book = new Book(1, "BookExample", 1,
                "982563", 1, 1000, new DateOnly(2023, 1, 1),
                new byte[1024], "Book description");

            book.CategoryId.Should().Be(1);
            book.Title.Should().Be("BookExample");
            book.PublisherId.Should().Be(1);
            book.Isbn.Should().Be("982563");
            book.AuthorId.Should().Be(1);
            book.PublicationDate.Should().Be(new DateOnly(2023, 1, 1));
            book.Price.Should().Be(1000);
        }

        [Fact]
        public void book_category_cannot_be_defined_without_name()
        {
            Action action = () => new Category("");

            action
                .Should()
                .Throw<NotEmptyException>();
        }
    }
}