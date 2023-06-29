using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using BookStore.Domain.Catalog.Models.InventoryAggregate;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Persistence.EF
{
    public class BookStoreDbContext : BaseDbContext
    {
        public BookStoreDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
            { }
        }
        public class DateOnlyComparer : ValueComparer<DateOnly>
        {
            public DateOnlyComparer() : base(
                (x, y) => x.DayNumber == y.DayNumber,
                dateOnly => dateOnly.GetHashCode())
            { }
        }
    }
}