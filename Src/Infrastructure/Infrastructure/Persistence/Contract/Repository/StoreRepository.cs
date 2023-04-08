using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Store;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.StoreEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class StoreRepository:IStoreRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public StoreRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region StoreGetAllAsync
    public async Task<PaginationDto<StoreDto>> StoreGetAllAsync(StoreSearchDto storeSearchDto,CancellationToken cancellationToken)
    {
        var query = _context.Stores.AsNoTracking().AsQueryable();
        if (storeSearchDto.ActiveType != 0)
        {
            if (storeSearchDto.ActiveType == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (storeSearchDto.ActiveType == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        if (!String.IsNullOrEmpty(storeSearchDto.Name)) query = query.Where(x => x.Name.Contains(storeSearchDto.Name));
        if (!String.IsNullOrEmpty(storeSearchDto.MobileNumber)) query = query.Where(x => x.MobileNumber.Contains(storeSearchDto.MobileNumber));
        if (!String.IsNullOrEmpty(storeSearchDto.PhoneNumber)) query = query.Where(x => x.PhoneNumber.Contains(storeSearchDto.PhoneNumber));
        
        if (!String.IsNullOrEmpty(storeSearchDto.UserId)) query = query.Where(x => x.UserId==storeSearchDto.UserId);
        if (storeSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id==storeSearchDto.Id);
        if (storeSearchDto.SortType == SortType.Desc) query = query.OrderByDescending(x => x.Id);
        if (storeSearchDto.SortType == SortType.Asc) query = query.OrderBy(x => x.Id);
        var count =await query.CountAsync(cancellationToken);
        var result = await query.Skip((storeSearchDto.PageIndex - 1) * storeSearchDto.PageSize).Take(storeSearchDto.PageSize).Include(x=>x.User).ToListAsync(cancellationToken);
        var data= _mapper.Map<IEnumerable<StoreDto>>(result);
        return new PaginationDto<StoreDto>(storeSearchDto.PageIndex, storeSearchDto.PageSize, count, data);
    }
    #endregion

    #region StoreGetByIdAsync
    public async Task<Store> StoreGetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        var store = await _context.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (store == null) throw new NotFoundEntityException(ApplicationMessages.StoreNotFound);
        return store;
    }
    #endregion

    #region StoreDeleteAsync
    public async Task<bool> StoreDeleteAsync(Guid id,CancellationToken cancellationToken)
    {
        var check=await _context.Stores.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedDelete);
    }
    #endregion

    #region StoreEditAsync
    public async Task<bool> StoreEditAsync(StoreEditDto storeEditDto,CancellationToken cancellationToken)
    {
        var check = await _context.Stores
            .Where(x => x.Id == storeEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , storeEditDto.Name)
                    .SetProperty(x=>x.Description,storeEditDto.Description)
                    .SetProperty(x=>x.Address,storeEditDto.Address)
                    .SetProperty(x=>x.MobileNumber,storeEditDto.MobileNumber)
                    .SetProperty(x=>x.PhoneNumber,storeEditDto.PhoneNumber)
                    .SetProperty(x=>x.IsActive,storeEditDto.IsActive)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                    .SetProperty(x=>x.UserId,storeEditDto.UserId)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.StoreFailedEdit);
    }
    #endregion

    #region StoreAddAsync
    public async Task<bool> StoreAddAsync(StoreAddDto storeAddDto,CancellationToken cancellationToken)
    {
        var store = new Store(storeAddDto.Name, storeAddDto.Address, storeAddDto.PhoneNumber, storeAddDto.MobileNumber, storeAddDto.Description, storeAddDto.UserId);
         await _context.Stores.AddAsync(store, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreAddFailed);
    }
    #endregion
    
    #region StoreExistAsync
    public async Task<bool> StoreExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Stores.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.StoreNotFound);
        return true;
    }
    #endregion
}