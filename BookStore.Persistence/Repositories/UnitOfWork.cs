using BookStore.Application.Contracts.Infrastructure;

namespace BookStore.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepository BookRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BookRepository ??= new BookRepository(context);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
