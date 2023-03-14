#region UsignAndNamespace
using System.Linq.Expressions;
using Application.IContracts.IBase;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.Specification;
using Application.IContracts.ISpecification;
using Domain.Entities.BaseEntity;
namespace Infrastructure.Persistence.Contract.Base;
#endregion
public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    #endregion

    #region GetByIdAsync
    public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(x=>x.Id==id, cancellationToken);
    }
    #endregion

    #region GetAllAsync
    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    #endregion

    #region AddAsync
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return await Task.FromResult(entity);
    }
    #endregion

    #region UpdateAsync
    public Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(entity);
    }
    #endregion

    #region DeleteLogicalAsync
    public async void DeleteLogicalAsync(T entity, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(entity.Id, cancellationToken);
        record.IsDelete = true;
        await UpdateAsync(entity);
    }
    #endregion

    #region AnyExpressionAsync
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(expression, cancellationToken);
    }
    #endregion

    #region AnyAsync
    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    #endregion


    //Specification
    #region GetEntityBySpecificationAsync
    public async Task<T> GetEntityBySpecificationAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }
    #endregion

    #region GetListEntityBySpecificationAsync
    public async Task<IReadOnlyList<T>> GetListEntityBySpecificationAsync(ISpecification<T> specification,CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }
    #endregion

    #region ApplySpecification
    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);
    }
    #endregion

    #region CountSpecificationAsync
    public async Task<int> CountSpecificationAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).CountAsync(cancellationToken);
    }
    #endregion
}

