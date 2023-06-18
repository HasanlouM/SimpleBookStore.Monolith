using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Catalog.Mappings
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "ctlg")
                .HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.PublicationDate)
                .IsRequired();

            builder.Property(b => b.Isbn)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Image)
                .IsRequired();

            builder.Property(b => b.Price)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.HasOne(typeof(Category))
                .WithMany()
                .IsRequired()
                .HasForeignKey(nameof(Book.CategoryId))
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(typeof(Author))
                .WithMany()
                .IsRequired()
                .HasForeignKey(nameof(Book.AuthorId))
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(typeof(Publisher))
                .WithMany()
                .IsRequired()
                .HasForeignKey(nameof(Book.PublisherId))
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(c => c.UncommittedEvents);
        }
    }
}