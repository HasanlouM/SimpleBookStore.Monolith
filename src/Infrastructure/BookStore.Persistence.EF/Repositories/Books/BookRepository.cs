using BookStore.Domain.Books.Model;

namespace BookStore.Persistence.EF.Repositories.Books
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
