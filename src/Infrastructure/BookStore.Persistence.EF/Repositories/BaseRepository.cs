using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Persistence.EF.Repositories;

public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : AggregateRoot<TKey>
{
    protected BookStoreDbContext DbContext;
    protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

    protected BaseRepository(BookStoreDbContext context)
    {
        DbContext = context;
    }

    public async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "",
        CancellationToken cancellation = default)
    {
        IQueryable<TEntity> query = DbSet;

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        orderBy?.Invoke(query);

        return query.AsEnumerable<TEntity>();
    }

    public Task<TEntity?> Get(TKey id, CancellationToken cancellation = default)
    {
        return DbSet.FirstOrDefaultAsync(c =>
            c.Id!.Equals(id), cancellation);
    }

    public async Task<TEntity> Add(
        TEntity entity, CancellationToken cancellation = default)
    {
        var ent = await DbSet.AddAsync(entity, cancellation);
        return ent.Entity;
    }

    public Task<bool> IsDeleted(TKey id, CancellationToken cancellation = default)
    {
        return DbSet.AnyAsync(c => c.Deleted, cancellation);
    }

    public Task<bool> Exists(TKey id, CancellationToken cancellation = default)
    {
        return DbSet.AnyAsync(c => c.Id!.Equals(id), cancellation);
    }
}