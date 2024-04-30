using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories
{
    public sealed class BookRepository(ApplicationDbContext dbContext)
        : GenericRepository<Book>(dbContext),
        IBookRepository
    {
    }
}
