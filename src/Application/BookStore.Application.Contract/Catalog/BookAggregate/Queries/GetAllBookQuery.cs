using Common.Application;

namespace BookStore.Application.Contract.Catalog.BookAggregate.Queries;

public class GetAllBookQuery : IQuery<IEnumerable<BookQueryModel>>
{
    public int? CategoryId { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }
    public DateOnly? PublicationDateFrom { get; set; }
    public DateOnly? PublicationDateTo { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
}