using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class UpdateBookImageCommand : IRequest<Unit>
{
    public required BookImageForUpdateDto BookImageForUpdateDto { get; set; }
}
