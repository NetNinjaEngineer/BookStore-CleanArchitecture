using System.CodeDom.Compiler;
using System.Diagnostics.Contracts;
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
    public async Task<IActionResult> GetAuthors() {
        var result = await Mediator.Send(new GetAuthorsQuery());
        return Ok(result);
    }
}
