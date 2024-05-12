namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> FindAll();

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
