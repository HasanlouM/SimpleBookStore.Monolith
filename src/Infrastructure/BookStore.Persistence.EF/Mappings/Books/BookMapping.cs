using BookStore.Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Persistence.EF.Mappings.Books
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "store")
                .HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Publisher)
                .IsRequired().
                HasMaxLength(100);
            
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

            builder.HasOne(typeof(BookCategory))
                .WithMany()
                .IsRequired()
                .HasForeignKey(nameof(Book.CategoryId))
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(c => c.UncommittedEvents);
        }
    }
}
