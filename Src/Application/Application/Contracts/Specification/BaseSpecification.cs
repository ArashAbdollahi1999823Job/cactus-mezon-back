#region UsignAndNamespace

using System.Linq.Expressions;
using Application.IContracts.ISpecification;
using Domain.Entities.BaseEntity;

namespace Application.Contracts.Specification;

#endregion

public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    #region Properties

    public Expression<Func<T, bool>> Predicate { get; private set; }
    public List<Expression<Func<T, object>>> Includes { get; private set; } = new();
    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    //Pagination
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool IsEnablePagination { get; set; } = false;

    #endregion

    #region Ctors

    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> predicate)
    {
        Predicate = predicate;
    }

    #endregion

    #region AddInclude

    protected void AddInclude(Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }

    #endregion

    #region AddOrderBy

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    #endregion

    #region AddOrderByDescending

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }

    #endregion

    #region ApplyPaging

    protected void ApplyPagination(int skip, int take, bool isEnablePagination = true)
    {
        Skip = skip;
        Take = take;
        IsEnablePagination = isEnablePagination;
    }

    #endregion
}