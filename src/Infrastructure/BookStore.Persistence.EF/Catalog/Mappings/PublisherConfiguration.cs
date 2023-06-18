using BookStore.Domain.Catalog.Models.PublisherAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EF.Catalog.Mappings;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers", Constants.Schema.Catalog)
            .HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(b => b.PhoneNumber)
            .IsRequired(false)
            .HasMaxLength(15);

        builder.Property(b => b.Email)
            .IsRequired(false)
            .HasMaxLength(200);

        builder.Property(a => a.Status)
            .IsRequired()
            .HasDefaultValue(PublisherStatus.Active);

        builder.Ignore(c => c.UncommittedEvents);
    }
}