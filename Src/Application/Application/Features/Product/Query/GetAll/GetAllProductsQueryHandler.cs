#region UsignAndNamespace

using Application.Dto.Base;
using Application.Dto.Product;
using Application.IContracts.IBase;
using AutoMapper;
using Domain.Entities.ProductEntity;
using MediatR;
namespace Application.Features.Products.Queries.GetAll;
#endregion
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationDto<ProductDto>>
{
    #region CtorAndInjection
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    #endregion

    public async Task<PaginationDto<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        /*var specification = new GetProductsSpecification(request);
        var count = await _uow.Repository<Product>().CountSpecificationAsync(new ProductsCountSpecification(request),cancellationToken);
        var result= await _uow.Repository<Product>().GetListEntityBySpecificationAsync(specification, cancellationToken);
        var listProductData= _mapper.Map<IEnumerable<ProductDto>>(result);*/
        return new PaginationDto<ProductDto>(/*request.PageIndex*/ 1, 1/*request.PageSize*/, 3, null);
    }
}

