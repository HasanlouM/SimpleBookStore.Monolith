using BookStore.Domain.Books.Model;
using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.EF
{
    public class BookStoreDbContext : BaseDbContext
    {
        public BookStoreDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
