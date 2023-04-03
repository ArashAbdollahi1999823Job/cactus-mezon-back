using Application.Dto.ProductPicture;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.ProductPicture.Query.ProductPictureGetAll;
public class ProductPictureGetAllQueryHandler:IRequestHandler<ProductPictureGetAllQuery,List<ProductPictureDto>>
{
    #region CtorAndInjection
    private readonly IProductPictureRepository _productPictureRepository;
    public ProductPictureGetAllQueryHandler(IProductPictureRepository productPictureRepository)
    {
        _productPictureRepository = productPictureRepository;
    }
    #endregion
    public async Task<List<ProductPictureDto>> Handle(ProductPictureGetAllQuery req, CancellationToken cancellationToken)
    {
        ProductPictureSearchDto productPictureSearchDto = new ProductPictureSearchDto(req.Id, req.ProductId);
        return await _productPictureRepository.ProductPictureGetAllAsync(productPictureSearchDto, cancellationToken);
    }
}