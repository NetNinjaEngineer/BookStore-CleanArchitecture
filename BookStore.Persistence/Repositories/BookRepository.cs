using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories
{
    public sealed class BookRepository(ApplicationDbContext dbContext)
        : GenericRepository<Book>(dbContext),
        IBookRepository
    {
        public bool Exists(int bookId)
            => dbContext.Books.Any(x => x.Id == bookId);
    }
}
