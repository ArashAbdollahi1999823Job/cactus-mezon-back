using Application.Common.Messages;
using Application.Dto.ProductPicture;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.ProductPicture.Command.ProductPictureAdd;
public class ProductPictureAddCommandHandler : IRequestHandler<ProductPictureAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IProductPictureRepository _productPictureRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFileUploader _fileUploader;
    public ProductPictureAddCommandHandler(IProductPictureRepository productPictureRepository,
        IProductRepository productRepository, IFileUploader fileUploader)
    {
        _productPictureRepository = productPictureRepository;
        _productRepository = productRepository;
        _fileUploader = fileUploader;
    }
    #endregion
    public async Task<bool> Handle(ProductPictureAddCommand req, CancellationToken cancellationToken)
    {
        string productName = _productRepository.ProductGetByIdAsync(req.ProductId, cancellationToken).Result.Name;
        var path = $"Picture/Product/{productName}";
        string pictureUrlString = _fileUploader.Upload(req.PictureUrl, path);
        if (pictureUrlString != null)
        {
            ProductPictureAddDto productPictureAddDto = new ProductPictureAddDto(req.PictureTitle, req.PictureTitle, pictureUrlString, req.Sort, req.ProductId);
            return await _productPictureRepository.ProductPictureAddAsync(productPictureAddDto, cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductPictureAddFailedOnHandle);
    }
}