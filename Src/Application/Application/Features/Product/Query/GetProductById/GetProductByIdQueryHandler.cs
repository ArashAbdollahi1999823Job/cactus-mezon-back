#region UsingAndNamespace

using Application.Common.Messages;
using Application.Dto.ProductsDto;
using Application.IContracts.IBase;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById;
#endregion
public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ProductDto>
{
    #region CtorAndInjection
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GetProductByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    } 
    #endregion

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        /*var specification = new GetProductsSpecification(request.Id);
        var result= await _uow.Repository<Product>().GetEntityBySpecificationAsync(specification, cancellationToken);
        if (result == null) throw new NotFoundEntityException(ApplicationMessages.RecordNotfound);*/
        return _mapper.Map<ProductDto>(null);
    }
}

