using BookStore.Domain.Catalog.Models.BookAggregate;

namespace BookStore.Persistence.EF.Catalog.Repositories
{
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
