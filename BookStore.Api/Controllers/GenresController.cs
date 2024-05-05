using BookStore.Api.Controllers;
using BookStore.Application.UseCases.Genre.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class GenresController
    (IMediator mediator) : BaseController(mediator)
{

    [HttpGet]
    public async Task<ActionResult<IQueryable<GenreForListDto>>> GetAllGenres()
    {
        var result = await mediator.Send(new GetAllGenreQuery());
        return Ok(result);
    }

}