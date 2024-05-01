using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Commands;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IQueryable<BookWithDetailsDto>>> GetBooksWithDetails()
        {
            var booksWithDetailsQuery = await mediator.Send(new GetAllBooksWithDetailsQuery());

            if (booksWithDetailsQuery.Any())
                return Ok(booksWithDetailsQuery);

            return NotFound("There is no books founded yet.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookWithDetailsDto>> GetBookWithDetails(int id)
        {
            var bookWithDetailsQuery = await mediator.Send(new GetBookWithDetailsQuery { Id = id });

            return bookWithDetailsQuery is null ? NotFound("Requested Book Not Founded.") : Ok(bookWithDetailsQuery);

        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] BookForCreationDto bookForCreationDto)
        {
            await mediator.Send(new CreateBookCommand
            {
                Image = bookForCreationDto.Image,
                BookForCreationDto = bookForCreationDto
            });

            return Ok(bookForCreationDto);
        }
    }
}
