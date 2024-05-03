using BookStore.Domain;

namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        bool Exists(int bookId);
    }
}
