using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Features.Product.Query.ProductGetAll;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Brand.Query.BrandGetAll;
public class BrandGetAllQueryHandler:IRequestHandler<BrandGetAllQuery,PaginationDto<BrandDto>>
{
    #region CtorAndInjection
    private readonly IBrandRepository _brandRepository;
    public BrandGetAllQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    #endregion
    public async Task<PaginationDto<BrandDto>> Handle(BrandGetAllQuery req, CancellationToken cancellationToken)
    {
        var brandSearchDto = new BrandSearchDto(req.PageIndex, req.PageSize, req.Id, req.Name);
        return await _brandRepository.BrandGetAllAsync(brandSearchDto, cancellationToken);
    }
}