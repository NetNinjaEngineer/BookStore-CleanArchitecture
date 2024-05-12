using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.UseCases.Genre.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Genre.Handlers.Queries;

public sealed class GetAllGenreQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
)
: IRequestHandler<GetAllGenreQuery, IEnumerable<GenreForListDto>>
{
    public async Task<IEnumerable<GenreForListDto>> Handle(
        GetAllGenreQuery request,
        CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<GenreForListDto>>(await unitOfWork.GenreRepository.FindAll());
}