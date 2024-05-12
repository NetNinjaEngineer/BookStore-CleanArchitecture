using BookStore.Application.Responses;
using MediatR;

namespace BookStore.Application.UseCases.Author.Requests.Queries;
public sealed class GetAuthorsWithDetailsQuery
    : IRequest<IEnumerable<GetAuthorsWithDetailsResponse>>
{
}
