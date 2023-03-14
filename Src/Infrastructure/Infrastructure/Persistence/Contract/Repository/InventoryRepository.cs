using Application.Dto.Inventory;
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
    public InventoryRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        throw new BadRequestEntityException("ApplicationMessages.InventoryAddFailed");
    }
    #endregion

    #region InventoryGetAllAsync
    public async Task<IEnumerable<InventoryDto>> InventoryGetAllAsync(InventorySearchDto inventorySearchDto,CancellationToken cancellationToken)
    {
        
        var query = _context.Inventories.AsNoTracking().AsQueryable();

        if (!String.IsNullOrEmpty(inventorySearchDto.Name)) query = query.Where(x => x.Name.Contains(inventorySearchDto.Name));
        if (inventorySearchDto.Id!=0) query = query.Where(x => x.Id==inventorySearchDto.Id);
        if (inventorySearchDto.StoreId!=0) query = query.Where(x => x.StoreId==inventorySearchDto.StoreId);
        if (inventorySearchDto.IsActive != 0)
        {
            if (inventorySearchDto.IsActive == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (inventorySearchDto.IsActive == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        var inventories =await query.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InventoryDto>>(inventories);
    }
    #endregion
}