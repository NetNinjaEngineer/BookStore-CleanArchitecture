using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorBooksRepository(ApplicationDbContext dbContext)
        : GenericRepository<AuthorBooks>(dbContext),
    IAuthorBooksRepository
{
}
