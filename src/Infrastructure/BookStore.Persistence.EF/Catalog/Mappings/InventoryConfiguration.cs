using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.InventoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Catalog.Mappings;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory", Constants.Schema.Catalog);

        builder.HasKey(x => x.Id);

        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.Property(i => i.ReorderThreshold)
            .IsRequired();

        builder.Property(i => i.BookId)
            .IsRequired();

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(i => i.BookId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(i => i.BookId).IsUnique();

        builder.Ignore(i => i.UncommittedEvents);
    }
}