using BookStore.Domain.Catalog.Models.BookAggregate;

namespace BookStore.Domain.Test.Unit.Catalog.TestUtilities
{
    internal class BookTestBuilder
    {
        private string _title = "Fundamental of Software Architecture";
        private int _categoryId = TestConstants.Category.Software;
        private int _publisherId = TestConstants.Publisher.OReilly;
        private int _authorId = TestConstants.Author.NealFord;
        private string _isbn = "a123";
        private decimal _price = 100;
        private DateOnly _publicationDate = DateOnly.FromDateTime(DateTime.Now);
        private byte[] _image = new byte[1024];
        private string _description;

        private BookTestBuilder() { }

        public static BookTestBuilder New()
        {
            return new BookTestBuilder();
        }

        public BookTestBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public BookTestBuilder WithCategory(int categoryId)
        {
            _categoryId = categoryId;
            return this;
        }

        public BookTestBuilder WrittenBy(int authorId)
        {
            _authorId = authorId;
            return this;
        }

        public BookTestBuilder PublishedBy(int publisherId)
        {
            _publisherId = publisherId;
            return this;
        }

        public BookTestBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public BookTestBuilder WithIsbn(string isbn)
        {
            _isbn = isbn;
            return this;
        }

        public BookTestBuilder PublishAt(DateOnly publicationDate)
        {
            _publicationDate = publicationDate;
            return this;
        }

        public Book Build()
        {
            return new Book(_categoryId, _title, _publisherId, _isbn, _authorId,
                _price, _publicationDate, _image, _description);
        }
    }
}
