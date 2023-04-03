using Application.Common.Messages;
using Application.Dto.ProductPicture;
using Application.Dto.TypePicture;
using Application.Features.TypePicture.Command.TypePictureEdit;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureEdit;
public class ProductPictureEditCommandHandler:IRequestHandler<ProductPictureEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IProductPictureRepository _productPictureRepository;
    public ProductPictureEditCommandHandler(IProductPictureRepository productPictureRepository)
    {
        _productPictureRepository = productPictureRepository;
    }
    #endregion
    public async Task<bool> Handle(ProductPictureEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _productPictureRepository.ProductPictureExistAsync(req.Id,cancellationToken);
        if (check)
        {
            ProductPictureEditDto productPictureEditDto = new ProductPictureEditDto(req.Id, req.PictureAlt, req.PictureTitle, req.Sort, req.IsActive);
            return await _productPictureRepository.ProductPictureEditAsync(productPictureEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.ProductPictureEditFailedOnHandle);
    }
}