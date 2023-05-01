using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.InventoryOperation;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.InventoryEntity;
using Domain.Enums;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class InventoryOperationRepository:IInventoryOperationRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public InventoryOperationRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region InventoryOperationGetAllAsync
    public async Task<PaginationDto<InventoryOperationDto>> InventoryOperationGetAllAsync(InventoryOperationSearchDto inventoryOperationSearchDto,CancellationToken cancellationToken)
    {
            var query = _context.InventoryOperations.AsNoTracking().AsQueryable();
        if (inventoryOperationSearchDto.Count!=-1) query = query.Where(x => x.Count==inventoryOperationSearchDto.Count);
        if (inventoryOperationSearchDto.Price!=0) query = query.Where(x => x.Price==inventoryOperationSearchDto.Price);
        if (inventoryOperationSearchDto.InventoryOperationType != InventoryOperationType.NotImportant)
        {
            if(inventoryOperationSearchDto.InventoryOperationType == InventoryOperationType.Increase)
                query = query.Where(x => x.InventoryOperationType=="1"); 
            if(inventoryOperationSearchDto.InventoryOperationType == InventoryOperationType.Decrease)
                query = query.Where(x => x.InventoryOperationType=="2"); 
            if(inventoryOperationSearchDto.InventoryOperationType == InventoryOperationType.Sale)
                query = query.Where(x => x.InventoryOperationType=="3");  
            if(inventoryOperationSearchDto.InventoryOperationType == InventoryOperationType.Bought)
                query = query.Where(x => x.InventoryOperationType=="4");
        }

        if (inventoryOperationSearchDto.StoreId.ToString() !="00000000-0000-0000-0000-000000000000")
            query = query.Where(x => x.Product.Inventory.StoreId == inventoryOperationSearchDto.StoreId);
        if (inventoryOperationSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id==inventoryOperationSearchDto.Id);
        if (inventoryOperationSearchDto.ProductId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.ProductId==inventoryOperationSearchDto.ProductId);
        if (inventoryOperationSearchDto.InventoryId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Product.InventoryId==inventoryOperationSearchDto.InventoryId);
        if (inventoryOperationSearchDto.SortType == SortType.Desc) query = query.OrderByDescending(x => x.Id);
        if (inventoryOperationSearchDto.SortType == SortType.Asc) query = query.OrderBy(x => x.Id);
        var count =await query.CountAsync(cancellationToken);
        var result = await query.Skip((inventoryOperationSearchDto.PageIndex - 1) * inventoryOperationSearchDto.PageSize)
            .Take(inventoryOperationSearchDto.PageSize)
            .Include(x=>x.Product)
            .ThenInclude(x=>x.Inventory)
            .ToListAsync(cancellationToken);
        var data= _mapper.Map<IEnumerable<InventoryOperationDto>>(result);
        return new PaginationDto<InventoryOperationDto>(inventoryOperationSearchDto.PageIndex, inventoryOperationSearchDto.PageSize, count, data);
    }

 

    #endregion
    
    #region InventoryOperationDeleteAsync
    public async Task<bool> InventoryOperationDeleteAsync(Guid id,CancellationToken cancellationToken)
    {
        var check=await _context.InventoryOperations.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.InventoryOperationDeleteFailed);
    }
    #endregion

    #region InventoryOperationAddAsync
    public async Task<bool> InventoryOperationAddAsync(InventoryOperationAddDto inventoryOperationAddDto,CancellationToken cancellationToken)
    {
        var inventoryOperation = new InventoryOperation(inventoryOperationAddDto.Description,
            inventoryOperationAddDto.Price,inventoryOperationAddDto.Count,inventoryOperationAddDto.InventoryOperationType.ToString(),inventoryOperationAddDto.ProductId);
         await _context.InventoryOperations.AddAsync(inventoryOperation, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.InventoryOperationAddFailed);
    }
    #endregion
    
    #region InventoryOperationExistAsync
    public async Task<bool> InventoryOperationExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.InventoryOperations.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.InventoryOperationNotFound);
        return true;
    }
    #endregion
}