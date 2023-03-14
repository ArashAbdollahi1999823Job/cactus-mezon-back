#region UsingAndNamespace

using System.Linq.Expressions;
using Domain.Entities.BaseEntity;

namespace Application.IContracts.ISpecification;
#endregion
public interface ISpecification<T> where T : BaseEntity
{
    #region Filters
    Expression<Func<T, bool>> Predicate { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    #endregion

    #region Pagination
    public int Take { get; }
    public int Skip { get;}
    public bool IsEnablePagination { get; }
    #endregion
}

