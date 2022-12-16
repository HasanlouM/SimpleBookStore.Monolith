using Microsoft.EntityFrameworkCore;

namespace SimpleFramework.Infrastructure.Persistence.EF;

public abstract class ReadOnlyDbContext : DbContext
{
    protected ReadOnlyDbContext(DbContextOptions<ReadOnlyDbContext> options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    public override int SaveChanges()
    {
        throw new InvalidOperationException("Cannot save data via read model");
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new InvalidOperationException("Cannot save data via read model");
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new CancellationToken())
    {
        throw new InvalidOperationException("Cannot save data via read model");
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new InvalidOperationException("Cannot save data via read model");
    }
}