using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using Common.Api;
using Common.Application;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Api.Controllers
{
    public class CategoriesController: MainController
    {
        private readonly ICommandBus _bus;
        private readonly IValidator<DefineCategoryCommand> _validator;

        public CategoriesController(
            ICommandBus bus, 
            IValidator<DefineCategoryCommand> validator)
        {
            _bus = bus;
            _validator = validator;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoryQueryModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<CategoryQueryModel>> Define(
            [FromBody] DefineCategoryCommand command, CancellationToken cancellation)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellation);
            if (!validationResult.IsValid)
            {
                return Fail(StatusCodes.Status400BadRequest, validationResult.ToString());
            }

            var category = await _bus.Dispatch<DefineCategoryCommand, CategoryQueryModel>(command, cancellation);

            if (category is null)
            {
                return Fail(
                    StatusCodes.Status500InternalServerError, "Operation has failed!");
            }

            return Created($"api/{ApiVersion}/Books/{category?.Id}/{nameof(CategoriesQueryController.Get)}",
                category);
        }
    }
}
