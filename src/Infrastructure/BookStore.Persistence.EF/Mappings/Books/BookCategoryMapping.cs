using BookStore.Domain.Books.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Mappings.Books;

public class BookCategoryMapping : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable("BookCategories", "store")
            .HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Ignore(c => c.UncommittedEvents);
    }
}