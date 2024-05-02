using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Author;
using BookStore.Application.UseCases.Author.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Author.Handlers.Queries;
public sealed class GetAuthorsQueryHandler(
  IUnitOfWork unitOfWork,
  IMapper mapper)
  : IRequestHandler<GetAuthorsQuery, List<AuthorForListDto>>
{
  public Task<List<AuthorForListDto>> Handle(
    GetAuthorsQuery request,
    CancellationToken cancellationToken
    )
  {
    var allAuthors = unitOfWork.AuthorRepository.FindAll();
    var mappedAuthors = mapper.Map<List<AuthorForListDto>>(allAuthors);
    return Task.FromResult(mappedAuthors);
  }
}