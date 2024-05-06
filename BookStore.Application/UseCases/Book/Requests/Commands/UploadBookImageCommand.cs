using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class UpdateBookImageCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
    public BookImageForUpdateDto BookImageForUpdateDto { get; set; }
}
