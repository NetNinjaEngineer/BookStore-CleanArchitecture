using BookStore.Application.Dtos.Book;
using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Queries;
public sealed class GetAllBooksWithDetailsQuery
    : IRequest<IQueryable<BookForListDto>>
{
}
