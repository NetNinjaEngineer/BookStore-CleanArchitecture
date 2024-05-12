using BookStore.Domain.Common;
using System.Linq.Expressions;

namespace BookStore.Application.Specifications;
public abstract class Specification<TEntity> where TEntity : BaseEntity
{
    public Specification() { }

    public Specification(Expression<Func<TEntity, bool>> criteria)
        => Criteria = criteria;

    public Expression<Func<TEntity, bool>>? Criteria { get; set; }

    public List<Expression<Func<TEntity, object>>>? Includes { get; } = [];

    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

    protected void AddIncludes(Expression<Func<TEntity, object>> includeExpression)
        => Includes?.Add(includeExpression);

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        => OrderBy = orderByExpression;
}
