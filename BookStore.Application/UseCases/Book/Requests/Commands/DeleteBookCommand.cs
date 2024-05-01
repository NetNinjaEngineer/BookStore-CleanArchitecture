using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class DeleteBookCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
}
