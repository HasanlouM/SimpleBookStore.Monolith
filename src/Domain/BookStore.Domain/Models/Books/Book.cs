using BookStore.Domain.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Models.Books
{
    public class Book : AggregateRoot<int>
    {
        public Book(int categoryId, string name, string code, string isbn, string author,
            decimal price, int publishYear, byte[] image, string description)
        {
            Guard.NotNullOrDefault(categoryId, Label.BookCategory);
            Guard.NotNullOrEmpty(name, Label.Book_Name);
            Guard.NotNullOrEmpty(isbn, Label.Book_Isbn);
            Guard.NotNullOrEmpty(author, Label.Book_Author);
            Guard.NotNullOrDefault(price, Label.Book_Price);
            Guard.NotNullOrDefault(publishYear, Label.Book_PublishYear);
            Guard.NotNull(image, Label.Book_Image);

            CategoryId = categoryId;
            Name = name;
            Code = code;
            Isbn = isbn;
            Author = author;
            Price = price;
            PublishYear = publishYear;
            Image = image;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public int PublishYear { get; private set; }
        public byte[] Image { get; private set; }
        public string Description { get; private set; }
    }
}
