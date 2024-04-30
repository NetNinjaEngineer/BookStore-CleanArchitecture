using BookStore.Application.Contracts.Infrastructure;

namespace BookStore.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository BookRepository { get; }

        public IAuthorRepository AuthorRepository { get; }

        public IGenreRepository GenreRepository { get; }

        public IAuthorBooksRepository AuthorBooksRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BookRepository ??= new BookRepository(context);
            AuthorRepository ??= new AuthorRepository(context);
            GenreRepository ??= new GenreRepository(context);
            AuthorBooksRepository ??= new AuthorBooksRepository(context);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
