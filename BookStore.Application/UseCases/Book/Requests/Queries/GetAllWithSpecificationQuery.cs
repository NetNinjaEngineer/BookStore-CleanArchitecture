using MediatR;

namespace BookStore.Application.UseCases.Book.Requests.Queries;
public sealed class GetAllWithSpecificationQuery : IRequest<IEnumerable<Domain.Book>>
{
}
