using BookStore.Application.Dtos.Author;
using MediatR;

namespace BookStore.Application.UseCases.Author.Requests.Queries;
public sealed class GetAuthorsQuery : IRequest<List<AuthorForListDto>> {
  
}