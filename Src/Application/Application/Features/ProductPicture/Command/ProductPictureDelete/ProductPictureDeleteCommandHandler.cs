using Application.Common.Messages;
using Application.Features.TypePicture.Command.TypePictureDelete;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureDelete;
public class ProductPictureCommandHandler:IRequestHandler<ProductPictureDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductPictureRepository _productPictureRepository;
    private readonly IFileUploader _fileUploader;
    public ProductPictureCommandHandler(IProductPictureRepository productPictureRepository, IFileUploader fileUploader)
    {
        _productPictureRepository = productPictureRepository;
        _fileUploader = fileUploader;
    }
    #endregion
    public async Task<bool> Handle(ProductPictureDeleteCommand req, CancellationToken cancellationToken)
    {
        var productPicture =await _productPictureRepository.ProductPictureGetByIdAsync(req.Id, cancellationToken);
        var checkDeleteFile =  _fileUploader.Delete(productPicture.PictureUrl);
        if (checkDeleteFile)
        {
           return await _productPictureRepository.ProductPictureDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductPictureDeleteFailedOnHandle);
    }
}