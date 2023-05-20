using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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

    #region ProductGetAllAsync
    public async Task<PaginationDto<ProductDto>> ProductGetAllAsync(ProductSearchDto productSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsQueryable();
        if (!String.IsNullOrEmpty(productSearchDto.Name)) query = query.Where(x => x.Name.Contains(productSearchDto.Name));
        if (!String.IsNullOrEmpty(productSearchDto.Slug)) query = query.Where(x => x.Slug.Contains(productSearchDto.Slug));
        if (productSearchDto.InventoryId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.InventoryId == productSearchDto.InventoryId);
        if (productSearchDto.BrandId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.BrandId == productSearchDto.BrandId);
        if (productSearchDto.Off != -1) query = query.Where(x => x.Off.OffPercent >= productSearchDto.Off);
        if (productSearchDto.Price != 0) query = query.Where(x => x.Price == productSearchDto.Price);
        if (productSearchDto.StoreId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Inventory.StoreId == productSearchDto.StoreId);

        if (productSearchDto.IsActive != 0)
        {
            if (productSearchDto.IsActive == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (productSearchDto.IsActive == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        if (productSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id ==productSearchDto.Id);
        if (productSearchDto.TypeId.ToString() !="00000000-0000-0000-0000-000000000001")
        {
            if (productSearchDto.TypeId.ToString() !="00000000-0000-0000-0000-000000000000") query = query
                .Where(x => x.Type.Id == productSearchDto.TypeId
                            ||x.Type.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.ParentType.Id==productSearchDto.TypeId);
        }

        var count = await query.CountAsync(cancellationToken);
        if (productSearchDto.SortType == SortType.Desc)
        {
            query = query.OrderByDescending(x => x.Id);
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }
        query = query
            .Include(x=>x.Type)
            .Include(x=>x.Brand)
            .Include(x=>x.Off)
            .Include(x=>x.Colors)
            .Include(x=>x.ProductItems)
            .Include(x=>x.Inventory)
            .ThenInclude(x=>x.Store)
            .ThenInclude(x=>x.User);
        var result = await query.Skip((productSearchDto.PageIndex - 1) * productSearchDto.PageSize).Take(productSearchDto.PageSize).ToListAsync(cancellationToken);
        var data = _mapper.Map<List<ProductDto>>(result);
        return new PaginationDto<ProductDto>(productSearchDto.PageIndex, productSearchDto.PageSize, count, data);
    }
    #endregion
    
    #region ProductAddAsync
    public async Task<bool> ProductAddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
    {
        var product = new Product(productAddDto.Name,productAddDto.Slug,productAddDto.Description,
            productAddDto.MetaDescription,productAddDto.Price,productAddDto.Summary,productAddDto.InventoryId
            ,productAddDto.TypeId,productAddDto.BrandId.ToString() =="00000000-0000-0000-0000-000000000000" ? null : productAddDto.BrandId);
        await _context.Products.AddAsync(product, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductAddFailed);
    }
    #endregion
    
    #region ProductEditAsync
    public async Task<bool> ProductEditAsync(ProductEditDto productEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.Products
            .Where(x => x.Id == productEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , productEditDto.Name)
                    .SetProperty(x => x.Price , productEditDto.Price)
                    .SetProperty(x => x.Slug , productEditDto.Slug)
                    .SetProperty(x=>x.Description,productEditDto.Description)
                    .SetProperty(x=>x.MetaDescription,productEditDto.MetaDescription)
                    .SetProperty(x=>x.Summary,productEditDto.Summary)
                    .SetProperty(x=>x.IsActive,productEditDto.IsActive)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                    .SetProperty(x=>x.TypeId,productEditDto.TypeId)
                    .SetProperty(x=>x.InventoryId,productEditDto.InventoryId)
                    .SetProperty(x=>x.BrandId,productEditDto.BrandId.ToString() =="00000000-0000-0000-0000-000000000000" ? null:productEditDto.BrandId)
                    .SetProperty(x=>x.OffId,productEditDto.OffId.ToString() =="00000000-0000-0000-0000-000000000000" ? null:productEditDto.OffId)

                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
    }
    #endregion
    
    #region ProductExistAsync
    public async Task<bool> ProductExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Products.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.ProductNotFound);
        return true;
    }
    #endregion
    
    #region ProductDeleteAsync
    public async Task<bool> ProductDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Products.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductDeleteFailed);
    }
    #endregion
    
    #region ProductGetByIdAsync
    public async Task<Product> ProductGetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (product == null) throw new NotFoundEntityException(ApplicationMessages.ProductNotFound);
        return product;
    }



    #endregion

    #region ProductChangeCountAsync

    public async Task<bool> ProductChangeCountAsync(int count, string inventoryOperationType, Guid productId,
        CancellationToken cancellationToken)
    {
        if (inventoryOperationType == "1" || inventoryOperationType == "4")
        {
            var check = await _context.Products
                .Where(x => x.Id == productId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count+count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
        else
        {
            var check = await _context.Products
                .Where(x => x.Id == productId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count-count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
                
                
    }

    #endregion
}