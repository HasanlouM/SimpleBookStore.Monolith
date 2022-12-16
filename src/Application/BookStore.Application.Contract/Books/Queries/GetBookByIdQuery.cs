using Common.Application;

namespace BookStore.Application.Contract.Books.Queries
{
    public class GetBookByIdQuery : IQuery<BookQueryModel>
    {
        public int Id { get; set; }
    }
}
