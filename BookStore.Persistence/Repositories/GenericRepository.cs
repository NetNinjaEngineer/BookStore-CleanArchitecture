using BookStore.Application.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
    public class GenericRepository<T>(ApplicationDbContext dbContext)
        : IGenericRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<T>> FindAll()
            => await _dbContext.Set<T>().ToListAsync();

        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
    }
}
