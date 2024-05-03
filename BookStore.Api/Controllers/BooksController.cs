﻿using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Commands;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController(IMediator mediator) : BaseController(mediator)
    {
        public IMediator Mediator { get; } = mediator;

        [HttpGet]
        public async Task<ActionResult<IQueryable<BookWithDetailsDto>>> GetAllBooksWithDetails()
        {
            try
            {
                var booksWithDetailsQuery = await Mediator.Send(new GetAllBooksWithDetailsQuery());
                return Ok(booksWithDetailsQuery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetBookDetail")]
        public async Task<ActionResult<BookWithDetailsDto>> GetBookWithDetails(int id)
        {
            try
            {
                var bookWithDetailsQuery = await Mediator.Send(new GetBookWithDetailsQuery { Id = id });
                return Ok(bookWithDetailsQuery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] BookForCreationDto bookForCreationDto)
        {
            try
            {
                var createdBook = await Mediator.Send(
                    new CreateBookCommand { BookForCreationDto = bookForCreationDto });
                return CreatedAtRoute("GetBookDetail", new { id = createdBook.Id }, createdBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromForm] BookForUpdateDto bookForUpdateDto)
        {
            try
            {
                await Mediator.Send(new UpdateBookCommand { BookId = id, BookForUpdateDto = bookForUpdateDto });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await Mediator.Send(new DeleteBookCommand { BookId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
