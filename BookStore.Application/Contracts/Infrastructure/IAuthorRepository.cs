using BookStore.Application.Specifications.Features.Author;
using BookStore.Domain;

namespace BookStore.Application.Contracts.Infrastructure;
public interface IAuthorRepository : IGenericRepository<Author>
{
    bool AuthorExists(int authorId);
    Task<IEnumerable<Author>> GetAuthorsWithDetailsSpecification(GetAllAuthorsWithBooksAndAuthorBooksSpecification spec);
}
