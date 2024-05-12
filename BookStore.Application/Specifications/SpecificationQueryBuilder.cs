using BookStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Specifications;
public static class SpecificationQueryBuilder
{
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> inputQuery,
        Specification<T> specification)
        where T : BaseEntity
    {
        var query = inputQuery;

        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.Includes is not null)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (specification.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        return query;
    }
}
