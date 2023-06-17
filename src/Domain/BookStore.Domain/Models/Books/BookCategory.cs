using BookStore.Domain.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Models.Books;

public class BookCategory : AggregateRoot<int>
{
    private BookCategory() { }

    public BookCategory(string name)
    {
        Guard.NotNullOrEmpty(name, Label.BookCategory_Name);

        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public string Name { get; private set; }

}