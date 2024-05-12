using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Commands;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController(IMediator mediator) : BaseController(mediator)
    {
        public IMediator Mediator { get; } = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<BookForListDto>), 200)]
        public async Task<ActionResult<IQueryable<BookForListDto>>> GetAllBooksWithDetails()
        {
            var booksWithDetailsQuery = await Mediator.Send(new GetAllBooksWithDetailsQuery());
            return Ok(booksWithDetailsQuery);
        }

        [HttpGet("{id}", Name = "GetBookDetail")]
        [ProducesResponseType(typeof(BookForListDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookForListDto>> GetBookWithDetails(int id)
        {
            var bookWithDetailsQuery = await Mediator.Send(new GetBookWithDetailsQuery { Id = id });
            return Ok(bookWithDetailsQuery);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookForListDto), 201)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateBook([FromForm] BookForCreationDto bookForCreationDto)
        {
            var createdBook = await Mediator.Send(
                     new CreateBookCommand { BookForCreationDto = bookForCreationDto });
            return CreatedAtRoute("GetBookDetail", new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBook(int id, [FromForm] BookForUpdateDto bookForUpdateDto)
        {
            await Mediator.Send(new UpdateBookCommand { BookId = id, BookForUpdateDto = bookForUpdateDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await Mediator.Send(new DeleteBookCommand { BookId = id });
            return NoContent();
        }

        [Route("{id}/UpdateBookImage")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBookImage(int id, [FromForm] BookImageForUpdateDto request)
        {
            await Mediator.Send(new UpdateBookImageCommand { BookId = id, BookImageForUpdateDto = request });
            return NoContent();
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string searchTerm)
        {
            return Ok(await Mediator.Send(new SearchBooksQuery { SearchTerm = searchTerm }));
        }
    }
}
