#region UsingAndNamespace

using Application.Common.Messages;
using Application.Dto.Product;
using Application.IContracts.IBase;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Products.Queries.GetProductBySlug;
#endregion
public class GetProductBySlugQueryHandler:IRequestHandler<GetProductBySlugQuery,ProductDto>
{
    #region CtorAndInjection
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GetProductBySlugQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    #endregion
    
    
    public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        /*var spec = new GetProductsSpecification(request.Slug);
        var result =await _uow.Repository<Product>().GetEntityBySpecificationAsync(spec, cancellationToken);
        if (result == null) throw new NotFoundEntityException(ApplicationMessages.RecordNotfound);*/
        return _mapper.Map<ProductDto>(null);
    }
}