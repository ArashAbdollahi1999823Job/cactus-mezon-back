using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Inventory;
using Application.Dto.Product;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.InventoryEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class InventoryRepository:IInventoryRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public InventoryRepository(ApplicationDbContext context, IMapper mapper, IProductRepository productRepository)
    {
        _context = context;
        _mapper = mapper;
        _productRepository = productRepository;
    }
    #endregion

    #region InventoryAddAsync
    public async Task<bool> InventoryAddAsync(InventoryAddDto inventoryAddDto,CancellationToken cancellationToken)
    {
        var inventory = new Inventory(inventoryAddDto.Name,inventoryAddDto.StoreId);
        await _context.Inventories.AddAsync(inventory, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.InventoryAddFailed);
    }
    #endregion

    #region InventoryGetAllAsync
    public async Task<IEnumerable<InventoryDto>> InventoryGetAllAsync(InventorySearchDto inventorySearchDto,CancellationToken cancellationToken)
    {
        
        var query = _context.Inventories.AsNoTracking().AsQueryable();

        if (!String.IsNullOrEmpty(inventorySearchDto.Name)) query = query.Where(x => x.Name.Contains(inventorySearchDto.Name));
        if (inventorySearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id==inventorySearchDto.Id);
        if (inventorySearchDto.StoreId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.StoreId==inventorySearchDto.StoreId);
        if (inventorySearchDto.IsActive != 0)
        {
            if (inventorySearchDto.IsActive == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (inventorySearchDto.IsActive == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        var inventories =await query.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InventoryDto>>(inventories);
    }
    #endregion

    #region InventoryGetByIdAsync
    public async Task<Inventory> InventoryGetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        var inventory = await _context.Inventories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (inventory == null) throw new NotFoundEntityException(ApplicationMessages.InventoryNotFound);
        return inventory;
    }
    #endregion
    
    #region InventoryDeleteAsync
    public async Task<bool> InventoryDeleteAsync(Guid id,CancellationToken cancellationToken)
    {
        #region productDelete
        var productSearchDto = new ProductSearchDto(
            1, 1000, new Guid("00000000-0000-0000-0000-000000000000"), ActiveType.NotImportant,
            null, null, 0, id, new Guid("00000000-0000-0000-0000-000000000000"),
            new Guid("00000000-0000-0000-0000-000000000000"), -1, SortType.Desc,
            new Guid("00000000-0000-0000-0000-000000000000"), false);
        var productDtos =  _productRepository.ProductGetAllAsync(productSearchDto, cancellationToken).Result.Data;

        if (productDtos.Any())
        {
            foreach (var productDto in productDtos)
            {
                await _productRepository.ProductDeleteAsync(productDto.Id,cancellationToken);
            }
        }
        #endregion
        
        var check=await _context.Inventories.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.InventoryFailedDelete);
    }
    #endregion
    
    #region InventoryEditAsync
    public async Task<bool> InventoryEditAsync(InventoryEditDto inventoryEditDto,CancellationToken cancellationToken)
    {
        var check = await _context.Inventories
            .Where(x => x.Id == inventoryEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , inventoryEditDto.Name)
                    .SetProperty(x=>x.IsActive,inventoryEditDto.IsActive)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.InventoryFailedEdit);
    }
    #endregion
    
    #region InventoryExistAsync
    public async Task<bool> InventoryExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Inventories.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.InventoryNotFound);
        return true;
    }
    #endregion
}