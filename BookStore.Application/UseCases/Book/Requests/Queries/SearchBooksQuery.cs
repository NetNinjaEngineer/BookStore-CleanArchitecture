using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Queries;
public sealed class SearchBooksQuery : IRequest<IEnumerable<BookForListDto>>
{
    public string? SearchTerm { get; set; }
}
