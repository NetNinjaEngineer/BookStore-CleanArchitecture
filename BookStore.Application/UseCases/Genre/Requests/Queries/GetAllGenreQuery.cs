using MediatR;

namespace BookStore.Application.UseCases.Genre.Requests.Queries;

public sealed class GetAllGenreQuery
    : IRequest<IEnumerable<GenreForListDto>>
{ }