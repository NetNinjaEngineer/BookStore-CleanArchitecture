using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Exceptions;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetBookWithDetailsQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<GetBookWithDetailsQuery, BookForListDto>
{
    public async Task<BookForListDto> Handle(
        GetBookWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var bookWithDetails = await unitOfWork.BookRepository
            .GetBookByIdWithSpecification(
                new GetBookByIdWithDetailsSpecification(request.Id))
            ?? throw new BookNotFoundException($"Book with ID {request.Id} not found.");


        return mapper.Map<BookForListDto>(bookWithDetails);
    }
}
