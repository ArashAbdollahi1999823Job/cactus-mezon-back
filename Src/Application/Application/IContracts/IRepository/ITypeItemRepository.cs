using Application.Dto.TypeItem;
using Domain.Entities.ProductEntity;

namespace Application.IContracts.IRepository;
public interface ITypeItemRepository
{
    public Task<bool> TypeItemAddAsync(TypeItemAddDto typeItemAddDto,CancellationToken cancellationToken);
    public Task<List<TypeItemDto>> TypeItemGetAllAsync(TypeItemSearchDto typeItemSearchDto, CancellationToken cancellationToken);
    public Task<bool> TypeItemExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> TypeItemDeleteAsync(Guid id, CancellationToken cancellationToken);
}