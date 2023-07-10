namespace BookStore.Domain.Catalog.Models.CategoryAggregate;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll(CancellationToken cancellation = default);
    Task<Category?> Get(int id, CancellationToken cancellation = default);
    Task<Category> Add(Category model, CancellationToken cancellation = default);
    Task<bool> Exists(int id, CancellationToken cancellation = default);
}