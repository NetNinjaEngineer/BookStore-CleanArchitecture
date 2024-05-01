using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorRepository(ApplicationDbContext dbContext)
    : GenericRepository<Author>(dbContext),
    IAuthorRepository
{
    public bool AuthorExists(int authorId)
        => dbContext.Authors.Any(x => x.Id == authorId);
}
