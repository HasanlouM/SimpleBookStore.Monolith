using BookStore.Domain.Catalog.Models.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Catalog.Mappings;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", Constants.Schema.Catalog)
            .HasKey(c => c.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(c => c.Name).IsUnique();

        builder.Ignore(c => c.UncommittedEvents);
    }
}