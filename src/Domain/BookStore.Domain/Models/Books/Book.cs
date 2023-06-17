using BookStore.Domain.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Models.Books
{
    public class Book : AggregateRoot<int>
    {
        private Book() { }

        public Book(int categoryId, string title, string publisher, string isbn, string author,
            decimal price, DateOnly publicationDate, byte[] image, string description)
        {
            Guard.NotNullOrDefault(categoryId, Label.BookCategory);
            Guard.NotNullOrEmpty(title, Label.Book_Title);
            Guard.NotNullOrEmpty(author, Label.Book_Author);
            Guard.NotNullOrEmpty(publisher, Label.Book_Publisher);
            Guard.NotNullOrDefault(publicationDate, Label.Book_PublicationDate);
            Guard.NotNullOrEmpty(isbn, Label.Book_Isbn);
            Guard.NotNullOrDefault(price, Label.Book_Price);
            Guard.NotNull(image, Label.Book_Image);

            CategoryId = categoryId;
            Title = title;
            Publisher = publisher;
            Isbn = isbn;
            Author = author;
            Price = price;
            PublicationDate = publicationDate;
            Image = image;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public int CategoryId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }
        public DateOnly PublicationDate { get; private set; }
        public string Isbn { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }
    }
}
