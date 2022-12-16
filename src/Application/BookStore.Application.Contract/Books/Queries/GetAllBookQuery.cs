using Common.Application;

namespace BookStore.Application.Contract.Books.Queries;

public class GetAllBookQuery : IQuery<IEnumerable<BookQueryModel>>
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int? PublishYearFrom { get; set; }
    public int? PublishYearTo { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
}