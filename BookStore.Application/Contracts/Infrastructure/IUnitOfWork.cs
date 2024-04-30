namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        Task SaveChangesAsync();
    }
}
