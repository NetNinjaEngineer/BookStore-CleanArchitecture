using BookStore.Application.Contracts.Persistence;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorBooksRepository(ApplicationDbContext dbContext)
        : GenericRepository<AuthorBooks>(dbContext),
    IAuthorBooksRepository
{
}
