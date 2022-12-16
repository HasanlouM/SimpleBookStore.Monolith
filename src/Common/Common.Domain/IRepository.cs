using System.Linq.Expressions;

namespace Common.Domain
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : AggregateRoot<TKey>
    {
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "",
            CancellationToken cancellation = default);

        Task<TEntity> Get(TKey id, CancellationToken cancellation = default);
        Task<TEntity> Add(TEntity entity, CancellationToken cancellation = default);
        Task<bool> IsDeleted(TKey id, CancellationToken cancellationToken = default);
        Task<bool> Exists(TKey id, CancellationToken cancellationToken = default);
    }
}