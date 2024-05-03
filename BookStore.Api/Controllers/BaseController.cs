using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
public class BaseController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;
}