using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using Common.Api;
using Common.Application;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Api.Controllers
{
    public class BooksController : MainController
    {
        private readonly ICommandBus _bus;
        private readonly IValidator<DefineBookCommand> _validator;

        public BooksController(
            ICommandBus bus, 
            IValidator<DefineBookCommand> validator)
        {
            _bus = bus;
            _validator = validator;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookQueryModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<BookQueryModel>> Define(
            [FromForm] DefineBookCommand command, CancellationToken cancellation)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellation);
            if (!validationResult.IsValid)
            {
                return Fail(StatusCodes.Status400BadRequest, validationResult.ToString());
            }

            var book = await _bus.Dispatch<DefineBookCommand, BookQueryModel>(command, cancellation);

            if (book is null)
            {
                return Fail(
                    StatusCodes.Status500InternalServerError, "Operation has failed!");
            }

            return Created($"api/{ApiVersion}/Books/{book?.Id}/{nameof(BooksQueryController.Get)}",
                book);
        }
    }
}
