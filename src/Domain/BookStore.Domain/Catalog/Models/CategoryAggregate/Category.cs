using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Catalog.Models.CategoryAggregate;

public class Category : AggregateRoot<int>
{
    private Category() { }

    public Category(string name)
    {
        Guard.NotNullOrEmpty(name, Label.Category_Name);

        Name = name;
        Status = CategoryStatus.Active;
        CreatedAt = DateTime.UtcNow;
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