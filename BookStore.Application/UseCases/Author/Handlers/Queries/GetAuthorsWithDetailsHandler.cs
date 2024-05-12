using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Responses;
using BookStore.Application.Specifications.Features.Author;
using BookStore.Application.UseCases.Author.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Author.Handlers.Queries;
public sealed class GetAuthorsWithDetailsHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<GetAuthorsWithDetailsQuery, IEnumerable<GetAuthorsWithDetailsResponse>>
{
    public async Task<IEnumerable<GetAuthorsWithDetailsResponse>> Handle(
        GetAuthorsWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var response = await unitOfWork
            .AuthorRepository
            .GetAuthorsWithDetailsSpecification(
                new GetAllAuthorsWithBooksAndAuthorBooksSpecification());

        return mapper.Map<IEnumerable<GetAuthorsWithDetailsResponse>>(response);
    }
}
