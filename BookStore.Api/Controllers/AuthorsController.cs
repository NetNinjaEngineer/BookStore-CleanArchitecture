using BookStore.Application.Dtos.Author;
using BookStore.Application.Responses;
using BookStore.Application.UseCases.Author.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[Route("api/[controller]")]
public class AuthorsController
    (IMediator mediator) : BaseController(mediator)
{
    public IMediator Mediator { get; } = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(List<AuthorForListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthors()
    {
        try
        {
            return Ok(await Mediator.Send(new GetAuthorsQuery()));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetAuthorsWithBooks")]
    [ProducesResponseType(typeof(IEnumerable<GetAuthorsWithDetailsResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthorsWithBooks()
    {
        try
        {
            return Ok(await Mediator.Send(new GetAuthorsWithDetailsQuery()));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
