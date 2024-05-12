using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Specifications;
using BookStore.Application.Specifications.Features.Author;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories;
public sealed class AuthorRepository(ApplicationDbContext dbContext)
    : GenericRepository<Author>(dbContext),
    IAuthorRepository
{
    public bool AuthorExists(int authorId)
        => _dbContext.Authors.Any(x => x.Id == authorId);

    public async Task<IEnumerable<Author>> GetAuthorsWithDetailsSpecification(
        GetAllAuthorsWithBooksAndAuthorBooksSpecification spec)
        => await SpecificationQueryBuilder.GetQuery(_dbContext.Authors, spec).ToListAsync();
}
