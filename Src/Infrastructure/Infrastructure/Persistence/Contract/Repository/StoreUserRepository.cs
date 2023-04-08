using Application.Common.Messages;
using Application.Dto.StoreUser;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.StoreEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contract.Repository;
public class StoreUserRepository:IStoreUserRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public StoreUserRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region StoreUserGetAsync
    public async Task<StoreUserDto> StoreUserGetAsync(StoreUserSearchDto storeUserSearchDto, CancellationToken cancellationToken)
    {
       var query = _context.Stores.AsNoTracking().AsQueryable();
       if (storeUserSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id == storeUserSearchDto.Id);
       if (!String.IsNullOrEmpty(storeUserSearchDto.UserId)) query = query.Where(x => x.UserId == storeUserSearchDto.UserId);
       var storeUser = await query.Include(x=>x.User).ToListAsync(cancellationToken);
       return _mapper.Map<Store, StoreUserDto>(storeUser.FirstOrDefault());
    }
    #endregion
    
    #region StoreEditAsync
    public async Task<bool> StoreUserEditAsync(StoreUserEditDto storeEditDto,CancellationToken cancellationToken)
    {
        var check = await _context.Stores
            .Where(x => x.Id == storeEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , storeEditDto.Name)
                    .SetProperty(x=>x.Description,storeEditDto.Description)
                    .SetProperty(x=>x.Address,storeEditDto.Address)
                    .SetProperty(x=>x.MobileNumber,storeEditDto.MobileNumber)
                    .SetProperty(x=>x.PhoneNumber,storeEditDto.PhoneNumber)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.StoreUserFailedEdit);
    }
    #endregion
}