using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Specifications;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
    public sealed class BookRepository(ApplicationDbContext dbContext)
        : GenericRepository<Book>(dbContext), IBookRepository
    {
        public bool Exists(int bookId)
            => dbContext.Books.Any(x => x.Id == bookId);

        public async Task<IEnumerable<Book>> GetAllWithSpecifications(
            GetAllBooksWithGenreAndAuthorsSpecification spec)
        {
            return await SpecificationQueryBuilder
                .GetQuery(dbContext.Books, spec)
                .ToListAsync();
        }
    }
}
