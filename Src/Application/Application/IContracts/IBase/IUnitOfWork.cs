#region UsignAndNamespace
using Domain.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
namespace Application.IContracts.IBase;
#endregion
public interface IUnitOfWork
{
    DbContext Context { get; }
    Task<int> Save(CancellationToken cancellationToken);
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
}

