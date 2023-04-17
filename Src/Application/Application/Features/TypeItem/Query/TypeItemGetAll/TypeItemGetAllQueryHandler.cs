using Application.Dto.TypeItem;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.TypeItem.Query.TypeItemGetAll;
public class TypeItemGetAllQueryHandler:IRequestHandler<TypeItemGetAllQuery,List<TypeItemDto>>
{
    #region CtorAndInjection
    private readonly ITypeItemRepository _typeItemRepository;
    public TypeItemGetAllQueryHandler(ITypeItemRepository typeItemRepository)
    {
        _typeItemRepository = typeItemRepository;
    }
    #endregion
    public async Task<List<TypeItemDto>> Handle(TypeItemGetAllQuery req, CancellationToken cancellationToken)
    {
        TypeItemSearchDto typeItemSearchDto = new TypeItemSearchDto(req.Id, req.TypeId);
        return await _typeItemRepository.TypeItemGetAllAsync(typeItemSearchDto, cancellationToken);
    }
}