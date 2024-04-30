using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorBooksRepository
    : GenericRepository<AuthorBooks>,
    IAuthorBooksRepository
{
    public AuthorBooksRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
