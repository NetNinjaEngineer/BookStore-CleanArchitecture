using BookStore.Domain;

namespace BookStore.Application.Contracts.Infrastructure;
public interface IAuthorRepository : IGenericRepository<Author>
{
    bool AuthorExists(int authorId);
}
