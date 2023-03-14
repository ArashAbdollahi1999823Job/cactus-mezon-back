using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.TypePicture.Query.TypePictureGetAll;
public class TypePictureGetAllQueryHandler:IRequestHandler<TypePictureGetAllQuery,List<TypePictureDto>>
{
    #region CtorAndInjection
    private readonly ITypePictureRepository _typePictureRepository;
    public TypePictureGetAllQueryHandler(ITypePictureRepository typePictureRepository)
    {
        _typePictureRepository = typePictureRepository;
    }
    #endregion
    public async Task<List<TypePictureDto>> Handle(TypePictureGetAllQuery req, CancellationToken cancellationToken)
    {
        TypePictureSearchDto typePictureSearchDto = new TypePictureSearchDto(req.Id, req.TypeId);
        return await _typePictureRepository.TypePictureGetAllAsync(typePictureSearchDto, cancellationToken);
    }
}