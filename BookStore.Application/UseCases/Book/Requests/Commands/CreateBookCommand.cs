using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class CreateBookCommand : IRequest<BookForListDto>
{
    public required BookForCreationDto BookForCreationDto { get; set; }
}
