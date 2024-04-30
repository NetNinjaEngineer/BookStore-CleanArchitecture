using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorRepository(ApplicationDbContext dbContext)
    : GenericRepository<Author>(dbContext),
    IAuthorRepository
{
}
