using BookStore.Application.Contract.Books.Commands;
using BookStore.Application.Contract.Books.Queries;
using Common.Api;
using Common.Application;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Api.Controllers
{
    public class BookCategoriesController: MainController
    {
        private readonly ICommandBus _bus;
        private readonly IValidator<DefineBookCategoryCommand> _validator;

        public BookCategoriesController(
            ICommandBus bus, 
            IValidator<DefineBookCategoryCommand> validator)
        {
            _bus = bus;
            _validator = validator;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookCategoryQueryModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<BookCategoryQueryModel>> Define(
            [FromBody] DefineBookCategoryCommand command, CancellationToken cancellation)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellation);
            if (!validationResult.IsValid)
            {
                return Fail(StatusCodes.Status400BadRequest, validationResult.ToString());
            }

            var category = await _bus.Dispatch<DefineBookCategoryCommand, BookCategoryQueryModel>(command);

            if (category is null)
            {
                return Fail(
                    StatusCodes.Status500InternalServerError, "Operation has failed!");
            }

            return Created($"api/{ApiVersion}/Books/{category?.Id}/{nameof(BookCategoriesQueryController.Get)}",
                category);
        }
    }
}
