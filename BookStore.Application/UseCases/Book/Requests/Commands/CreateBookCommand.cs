using BookStore.Application.Dtos.Book;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class CreateBookCommand : IRequest<Unit>
{
    public required BookForCreationDto BookForCreationDto { get; set; }
    public required IFormFile Image { get; set; }
}
