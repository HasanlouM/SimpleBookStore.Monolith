using Common.Application;

namespace BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;

public class GetCategoryByIdQuery : IQuery<CategoryQueryModel>
{
    public int Id { get; set; }
}