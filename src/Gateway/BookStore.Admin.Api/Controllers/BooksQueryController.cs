using BookStore.Application.Contract.Books.Queries;
using Common.Api;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Api.Controllers;

public class BooksQueryController : MainController
{
    private readonly IQueryBus _bus;

    public BooksQueryController(IQueryBus bus)
    {
        _bus = bus;
    }

    [HttpGet("{id}/[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookQueryModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Produces("application/json")]
    public async Task<ActionResult<BookQueryModel>> Get(
        [FromRoute] int id)
    {
        var query = new GetBookByIdQuery
        {
            Id = id
        };
        var book = await _bus.Dispatch<GetBookByIdQuery, BookQueryModel>(query);

        return Ok(book);
    }

    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookQueryModel>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Produces("application/json")]
    public async Task<ActionResult<IEnumerable<BookQueryModel>>> GetAll(
        [FromQuery] GetAllBookQuery query)
    {
        var books = 
            await _bus.Dispatch<GetAllBookQuery, IEnumerable<BookQueryModel>>(query);

        return Ok(books);
    }
}