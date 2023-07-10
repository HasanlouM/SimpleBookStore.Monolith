using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;
using Common.Domain.Utils;

namespace BookStore.Domain.Catalog.Models.CategoryAggregate;

public class Category : AggregateRoot<int>
{
    private Category() { }

    public Category(string name, IClock clock)
    {
        Guard.NotNullOrEmpty(name, Label.Category_Name);

        Name = name;
        Status = CategoryStatus.Active;
        CreatedAt = clock.Now;
    }

    public string Name { get; private set; }
    public CategoryStatus Status { get; private set; }

    public void Inactivate()
    {
        Status = CategoryStatus.Inactive;
    }

    public void Activate()
    {
        Status = CategoryStatus.Active;
    }
}