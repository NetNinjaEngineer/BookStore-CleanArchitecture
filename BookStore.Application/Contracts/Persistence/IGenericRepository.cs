namespace BookStore.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> FindAll();

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
