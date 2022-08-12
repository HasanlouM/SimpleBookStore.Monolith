using SimpleFramework.Domain;

namespace BookStore.Domain.Books.Model
{
    public class Book : AggregateRoot<int>
    {
        public Book(int categoryId, string name, string code, string isbn, string author,
            decimal price, int publishYear, string image, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Code = code;
            Isbn = isbn;
            Author = author;
            Price = price;
            PublishYear = publishYear;
            Image = image;
            Description = description;
        }

        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public int PublishYear { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
    }
}
