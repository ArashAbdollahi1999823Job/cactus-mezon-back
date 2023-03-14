using Application.Common.Messages;
using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureAdd;
public class TypePictureAddCommandHandler : IRequestHandler<TypePictureAddCommand, bool>
{
    #region CtorAndInjection
    private readonly ITypePictureRepository _typePictureRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IFileUploader _fileUploader;
    public TypePictureAddCommandHandler(ITypePictureRepository typePictureRepository, ITypeRepository typeRepository, IFileUploader fileUploader)
    {
        _typePictureRepository = typePictureRepository;
        _typeRepository = typeRepository;
        _fileUploader = fileUploader;
    }
    #endregion


    public async Task<bool> Handle(TypePictureAddCommand req, CancellationToken cancellationToken)
    {
            string typeName = _typeRepository.TypeGetByIdAsync(req.TypeId, cancellationToken).Result.Name;
        var path = $"Picture/Type/{typeName}";
        string pictureUrlString = _fileUploader.Upload(req.PictureUrl, path);
        if (pictureUrlString != null)
        {
            TypePictureAddDto typePictureAddDto = new TypePictureAddDto(req.PictureTitle,req.PictureTitle,pictureUrlString,req.Sort,req.TypeId);
            return await _typePictureRepository.TypePictureAddAsync(typePictureAddDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedAddOnHandle);
    }
}