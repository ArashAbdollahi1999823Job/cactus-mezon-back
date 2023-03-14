using Application.Dto.Base;
using Application.Dto.Type;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Type.Query.TypeGetAll;
public class TypeGetAllQueryHandler:IRequestHandler<TypeGetAllQuery,PaginationDto<TypeDto>>
{
    #region CtorAndNamespace
    private readonly ITypeRepository _typeRepository;
    public TypeGetAllQueryHandler(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    #endregion
    public async Task<PaginationDto<TypeDto>> Handle(TypeGetAllQuery req, CancellationToken cancellationToken)
    {
        var typeSearchDto = new TypeSearchDto(req.PageIndex,req.PageSize,req.Id,req.IsActive,req.Name,req.ParentTypeId,req.SortType);
        return await _typeRepository.TypeGetAllAsync(typeSearchDto, cancellationToken);
    }
}

