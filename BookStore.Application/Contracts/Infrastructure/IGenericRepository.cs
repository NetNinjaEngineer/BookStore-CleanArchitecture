using System.Linq.Expressions;

namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition,
            params Expression<Func<T, object>>[] includes);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
