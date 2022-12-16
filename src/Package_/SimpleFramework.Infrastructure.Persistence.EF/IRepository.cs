using SimpleFramework.Domain;

namespace SimpleFramework.Infrastructure.Persistence.EF;

public interface IRepository<TRoot, in TKey> where TRoot : AggregateRoot<TKey>
{
    Task<List<TRoot>> GetAll(CancellationToken cancellationToken);

    Task<TRoot?> Get(TKey id, CancellationToken cancellationToken);

    Task<TRoot> Add(TRoot aggregate, CancellationToken cancellationToken);

    Task<bool> Exists(TKey id, CancellationToken cancellationToken);
}