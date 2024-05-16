using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetAllBooksWithDetailsQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
        : IRequestHandler<GetAllBooksWithDetailsQuery, IEnumerable<BookForListDto>>
{
    public async Task<IEnumerable<BookForListDto>> Handle(
        GetAllBooksWithDetailsQuery request,
        CancellationToken cancellationToken
        )
        => mapper.Map<IEnumerable<BookForListDto>>(
            await unitOfWork.BookRepository.GetAllWithSpecifications(new GetAllBooksWithGenreAndAuthorsSpecification()));
}