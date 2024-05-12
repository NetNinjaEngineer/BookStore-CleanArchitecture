using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class SearchBooksQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<SearchBooksQuery, IEnumerable<BookForListDto>>
{
    public async Task<IEnumerable<BookForListDto>> Handle(
        SearchBooksQuery request,
        CancellationToken cancellationToken)
    {
        var searchedBooks = await unitOfWork.BookRepository
            .SearchBooksWithSpecification(new SearchBooksSpecification(request.SearchTerm!));

        return mapper.Map<IEnumerable<BookForListDto>>(searchedBooks);
    }
}
