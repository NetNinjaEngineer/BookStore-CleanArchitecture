using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Specifications;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
    public sealed class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Exists(int bookId)
            => _dbContext.Books.Any(x => x.Id == bookId);

        public async Task<IEnumerable<Book>> GetAllWithSpec(
            GetAllBooksWithGenreAndAuthorsSpecification spec)
        {
            return await SpecificationQueryBuilder.GetQuery(_dbContext.Books, spec).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithSpecifications(
            GetAllBooksWithGenreAndAuthorsSpecification spec)
        {
            return await SpecificationQueryBuilder
                .GetQuery(_dbContext.Books, spec)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int bookId)
            => await _dbContext.Books.FindAsync(bookId);

        public async Task<Book?> GetBookByIdWithSpecification(GetBookByIdWithDetailsSpecification spec)
            => await SpecificationQueryBuilder.GetQuery(_dbContext.Books, spec).FirstOrDefaultAsync();

        public async Task<IEnumerable<Book>> SearchBooksWithSpecification(SearchBooksSpecification spec)
            => await SpecificationQueryBuilder.GetQuery(_dbContext.Books, spec).ToListAsync();
    }
}
