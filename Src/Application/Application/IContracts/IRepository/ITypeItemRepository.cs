using Application.Dto.TypeItem;
using Domain.Entities.ProductEntity;

namespace Application.IContracts.IRepository;
public interface ITypeItemRepository
{
    public Task<bool> TypeItemAddAsync(TypeItemAddDto typeItemAddDto,CancellationToken cancellationToken);
    public Task<List<TypeItemDto>> TypeItemGetAllAsync(TypeItemSearchDto typeItemSearchDto, CancellationToken cancellationToken);
    public Task<TypeItem> TypeItemGetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<bool> TypeItemExistAsync(long id,CancellationToken cancellationToken);
    public Task<bool> TypeItemDeleteAsync(long id, CancellationToken cancellationToken);
}