using BookStore.Domain.Books.Model;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit
{
    public class BookTests
    {
        [Fact]
        public void Define_a_book_properly()
        {
            var book = new Book(1, "BookExample", "1020",
                "982563","BookAuthor", 1000, 2022,
                new byte [1024], "Book description");

            book.CategoryId.Should().Be(1);
            book.Name.Should().Be("BookExample");
            book.Code.Should().Be("1020");
            book.Isbn.Should().Be("982563");
            book.Author.Should().Be("BookAuthor");
            book.PublishYear.Should().Be(2022);
            book.Price.Should().Be(1000);
        }
    }
}