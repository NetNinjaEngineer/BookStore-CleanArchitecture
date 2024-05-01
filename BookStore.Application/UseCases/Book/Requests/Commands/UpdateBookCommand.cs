using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class UpdateBookCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
    public required BookForUpdateDto BookForUpdateDto { get; set; }
}
