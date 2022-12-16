using Common.Application;

namespace BookStore.Application.Contract.Books.Queries;

public class GetBookCategoryByIdQuery : IQuery<BookCategoryQueryModel>
{
    public int Id { get; set; }
}