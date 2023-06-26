using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using Common.Api;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Api.Controllers
{
    public class CategoriesQueryController : MainController
    {
        private readonly IQueryBus _bus;

        public CategoriesQueryController(IQueryBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{id}/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryQueryModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<CategoryQueryModel>> Get(
            [FromRoute] int id)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id
            };

            var category =
                await _bus.Dispatch<GetCategoryByIdQuery, CategoryQueryModel?>(query);

            return Ok(category);
        }
    }
}
