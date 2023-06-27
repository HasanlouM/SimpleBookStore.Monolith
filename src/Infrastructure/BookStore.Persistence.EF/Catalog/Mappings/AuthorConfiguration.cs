using BookStore.Domain.Catalog.Models.AuthorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Catalog.Mappings;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors", Constants.Schema.Catalog)
            .HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.LastName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(b => b.Bio)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(a => a.Status)
            .IsRequired()
            .HasDefaultValue(AuthorStatus.Active);

        builder.HasIndex(c => new { c.FirstName, c.LastName }).IsUnique();

        builder.Ignore(c => c.FullName);
        builder.Ignore(c => c.UncommittedEvents);
    }
}