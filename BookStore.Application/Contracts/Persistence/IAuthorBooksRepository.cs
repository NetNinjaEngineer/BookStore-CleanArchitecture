using BookStore.Domain;

namespace BookStore.Application.Contracts.Persistence
{
    public interface IAuthorBooksRepository : IGenericRepository<AuthorBooks>
    {
    }
}
