using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Catalog.Models.BookAggregate
{
    public class Book : AggregateRoot<int>
    {
        private Book() { }

        public Book(int categoryId, string title, int publisherId, string isbn, int authorId,
            decimal price, DateOnly publicationDate, byte[] image, string description)
        {
            Guard.NotNullOrDefault(categoryId, Label.Category);
            Guard.NotNullOrEmpty(title, Label.Book_Title);
            Guard.NotNullOrDefault(authorId, Label.Book_Author);
            Guard.NotNullOrDefault(publisherId, Label.Book_Publisher);
            Guard.NotNullOrDefault(publicationDate, Label.Book_PublicationDate);
            Guard.NotNullOrEmpty(isbn, Label.Book_Isbn);
            Guard.NotNullOrDefault(price, Label.Book_Price);
            Guard.NotNull(image, Label.Book_Image);

            CategoryId = categoryId;
            Title = title;
            PublisherId = publisherId;
            Isbn = isbn;
            AuthorId = authorId;
            Price = price;
            PublicationDate = publicationDate;
            Image = image;
            Description = description;
            Status = BookStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public int CategoryId { get; private set; }
        public string Title { get; private set; }
        public int AuthorId { get; private set; }
        public int PublisherId { get; private set; }
        public DateOnly PublicationDate { get; private set; }
        public string Isbn { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }
        public BookStatus Status { get; private set; }

        public void Activate()
        {
            Status = BookStatus.Active;
        }

        public void Inactivate()
        {
            Status = BookStatus.Inactive;
        }
    }
}
