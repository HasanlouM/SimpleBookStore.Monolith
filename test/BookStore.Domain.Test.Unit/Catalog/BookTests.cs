using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Test.Unit.Catalog.TestUtilities;
using FluentAssertions;

namespace BookStore.Domain.Test.Unit.Catalog;

public class BookTests
{

    [Fact]
    public void Define_a_book()
    {
        // Delegated Fixture Setup 
        var title = "Fundamental of Software Architecture";
        var category = TestConstants.Category.Software;
        var author = TestConstants.Author.NealFord;
        var publisher = TestConstants.Publisher.OReilly;
        var publicationDate = DateOnly.Parse("2020/01/01");
        var isbn = "9781492043454";
        var price = 36.66M;

        // Exercise
        var book = BookTestBuilder.New()
            .WithTitle(title)
            .WithCategory(category)
            .WrittenBy(author)
            .PublishedBy(publisher)
            .PublishAt(publicationDate)
            .WithIsbn(isbn)
            .WithPrice(price)
            .Build();

        // Verification
        book.Title.Should().Be(title);
        book.CategoryId.Should().Be(category);
        book.PublisherId.Should().Be(publisher);
        book.Isbn.Should().Be(isbn);
        book.AuthorId.Should().Be(author);
        book.PublicationDate.Should().Be(publicationDate);
        book.Price.Should().Be(price);
    }

    [Fact]
    public void Inactive_a_book()
    {
        var book = BookTestBuilder.New().Build();
        book.Inactivate();

        book.Status.Should().Be(BookStatus.Inactive);
    }

    [Fact]
    public void Active_a_book()
    {
        var book = BookTestBuilder.New().Build();
        book.Activate();

        book.Status.Should().Be(BookStatus.Active);
    }
}