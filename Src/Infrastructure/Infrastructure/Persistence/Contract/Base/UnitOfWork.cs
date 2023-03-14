#region UsingAndNamespace

using Application.IContracts.IBase;
using Domain.Entities.BaseEntity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contract.Base;
#endregion
public class UnitOfWork:IUnitOfWork
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion
    public DbContext Context => _context;
    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        return new GenericRepository<T>(_context);
    }
}

