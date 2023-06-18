using Common.Application;

namespace BookStore.Application.Contract.Catalog.BookAggregate.Queries
{
    public class GetBookByIdQuery : IQuery<BookQueryModel>
    {
        public int Id { get; set; }
    }
}
