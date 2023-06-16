using BookStore.Domain.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Models.Books;

public class BookCategory : AggregateRoot<int>
{
    public BookCategory(string title)
    {
        Guard.NotNullOrEmpty(title, Label.BookCategory_Title);

        Title = title;
        CreatedAt = DateTime.UtcNow;
    }

    public string Title { get; private set; }

}