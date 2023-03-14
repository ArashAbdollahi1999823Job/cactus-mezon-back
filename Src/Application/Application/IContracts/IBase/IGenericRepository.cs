#region UsingAndNamespace

using System.Linq.Expressions;
using Application.IContracts.ISpecification;
using Domain.Entities.BaseEntity;

namespace Application.IContracts.IBase;
#endregion

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(long id,CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    void DeleteLogicalAsync(T entity,CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression,CancellationToken cancellationToken);
    Task<bool> AnyAsync(CancellationToken cancellationToken);

    //specifications
    Task<T> GetEntityBySpecificationAsync(ISpecification<T> specification,CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetListEntityBySpecificationAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<int> CountSpecificationAsync(ISpecification<T> specification,CancellationToken cancellationToken);
}

