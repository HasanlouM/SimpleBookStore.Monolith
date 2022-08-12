using SimpleFramework.Domain;

namespace BookStore.Domain.Books.Model;

public class BookCategory : AggregateRoot<int>
{
    public BookCategory(string title)
    {
        Title = title;
    }

    public string Title { get; private set; }

}