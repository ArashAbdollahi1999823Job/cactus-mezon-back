#region UsingAndNamesapce

using Application.IContracts.ISpecification;
using Domain.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts.Specification;
#endregion

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery.AsQueryable();

        if (specification.Predicate != null)
            query = query.Where(specification.Predicate);
        if (specification.Includes.Any())
            query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));
        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);
        if (specification.OrderByDescending != null)
            query = query.OrderByDescending(specification.OrderByDescending);
        if (specification.IsEnablePagination)
            query = query.Skip(specification.Skip).Take(specification.Take);

        return query;
    }
}

