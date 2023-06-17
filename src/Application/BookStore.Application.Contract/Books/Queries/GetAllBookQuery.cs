using Common.Application;

namespace BookStore.Application.Contract.Books.Queries;

public class GetAllBookQuery : IQuery<IEnumerable<BookQueryModel>>
{
    public int? CategoryId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateOnly? PublicationDateFrom { get; set; }
    public DateOnly? PublicationDateTo { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
}