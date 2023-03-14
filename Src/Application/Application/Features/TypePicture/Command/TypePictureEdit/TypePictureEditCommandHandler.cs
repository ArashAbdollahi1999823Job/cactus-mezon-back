using Application.Common.Messages;
using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureEdit;
public class TypePictureEditCommandHandler:IRequestHandler<TypePictureEditCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypePictureRepository _typePictureRepository;
    public TypePictureEditCommandHandler(ITypePictureRepository typePictureRepository)
    {
        _typePictureRepository = typePictureRepository;
    }
    #endregion
    public async Task<bool> Handle(TypePictureEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _typePictureRepository.TypePictureExistAsync(req.Id,cancellationToken);
        if (check)
        {
            TypePictureEditDto typePictureEditDto = new TypePictureEditDto(req.Id, req.PictureAlt, req.PictureTitle, req.Sort, req.IsActive);
            return await _typePictureRepository.TypePictureEditAsync(typePictureEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedEditOnHandle);
    }
}