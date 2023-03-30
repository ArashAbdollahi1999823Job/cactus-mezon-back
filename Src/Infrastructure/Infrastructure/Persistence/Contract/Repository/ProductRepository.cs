using Application.Common.Messages;
using Application.Dto.ProductDto;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Contract.Repository;
public class ProductRepository:IProductRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion
    public async Task<bool> ProductAddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
    {
        var product = new Product(productAddDto.Name,productAddDto.Slug,productAddDto.Description,
            productAddDto.MetaDescription,productAddDto.Price,productAddDto.Summary,productAddDto.InventoryId
            ,productAddDto.TypeId,productAddDto.BrandId == 0 ? null : productAddDto.BrandId);
        await _context.Products.AddAsync(product, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductAddFailed);
    }
}