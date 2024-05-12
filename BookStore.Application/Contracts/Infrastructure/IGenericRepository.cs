using System.Linq.Expressions;

namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> FindAll(params Expression<Func<T, object>>[] includes);

        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition,
            params Expression<Func<T, object>>[] includes);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
