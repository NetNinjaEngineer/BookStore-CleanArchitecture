namespace BookStore.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IGenreRepository GenreRepository { get; }
        IAuthorBooksRepository AuthorBooksRepository { get; }

        Task SaveChangesAsync();
    }
}
