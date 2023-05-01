using Application.Common.Messages;
using Application.Dto.ProductItem;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class ProductItemRepository : IProductItemRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductItemRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region ProductItemGetAllAsync
    public async Task<List<ProductItemDto>> ProductItemGetAllAsync(ProductItemSearchDto productItemSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.ProductItems.AsQueryable().AsNoTracking();
        if(productItemSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.Id == productItemSearchDto.Id);
        if(productItemSearchDto.ProductId.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.ProductId == productItemSearchDto.ProductId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<ProductItemDto>>(result);
    }
    #endregion

    #region ProductItemAddAsync
    public async Task<bool> ProductItemAddAsync(ProductItemAddDto productItemAddDto,CancellationToken cancellationToken)
    {
        var productItem = new ProductItem(productItemAddDto.Name,productItemAddDto.Value,productItemAddDto.ProductId);
        await _context.ProductItems.AddAsync(productItem,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductItemFailedAdd);
    }
    #endregion

    #region ProductItemGetById
    public async Task<ProductItem> ProductItemGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var productItem = await _context.ProductItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (productItem == null) throw new BadHttpRequestException(ApplicationMessages.ProductItemNotFound);
        return productItem;
    }

    #endregion

    #region ProductItemDelete
    public async Task<bool> ProductItemDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check=await _context.ProductItems.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductItemFailedDelete);
    }
    #endregion

    #region ProductItemExistAsync
    public async Task<bool> ProductItemExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.ProductItems.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.ProductItemNotFound);
        return true;
    }
    #endregion
}