using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.UseCases.Book.Requests.Commands;
public sealed class UpdateBookImageCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
    public required IFormFile ImageToUpload { get; set; }
}
