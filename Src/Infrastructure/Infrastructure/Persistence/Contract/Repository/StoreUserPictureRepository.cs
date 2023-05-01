using Application.Common.Messages;
using Application.Dto.StoreUserPicture;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.PictureEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class StoreUserPictureRepository : IStoreUserPictureRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public StoreUserPictureRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region StoreUserPictureGetAllAsync
    public async Task<List<StoreUserPictureDto>> StoreUserPictureGetAllAsync(StoreUserPictureSearchDto storeUserPictureSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.StorePictures.AsQueryable();
        if(storeUserPictureSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.Id == storeUserPictureSearchDto.Id);
        if(storeUserPictureSearchDto.StoreId.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.StoreId == storeUserPictureSearchDto.StoreId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<StoreUserPictureDto>>(result);
    }
    #endregion

    #region StoreUserPictureAddAsync
    public async Task<bool> StoreUserPictureAddAsync(StoreUserPictureAddDto storeUserPictureAddDto,CancellationToken cancellationToken)
    {
        var storePicture = new StorePicture(storeUserPictureAddDto.PictureTitle,storeUserPictureAddDto.PictureAlt,storeUserPictureAddDto.PictureUrlString,storeUserPictureAddDto.Sort,storeUserPictureAddDto.StoreId);
        await _context.StorePictures.AddAsync(storePicture,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.StoreUserPictureFailedAdd);
    }
    #endregion

    #region StoreUserPictureGetById
    public async Task<StorePicture> StoreUserPictureGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var storePicture = await _context.StorePictures.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (storePicture == null) throw new BadHttpRequestException(ApplicationMessages.StoreUserPictureNotFound);
        return storePicture;
    }
    #endregion

    #region StoreUserPictureEditAsync
    public async Task<bool> StoreUserPictureEditAsync(StoreUserPictureEditDto storeUserPictureEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.StorePictures.Where(x => x.Id == storeUserPictureEditDto.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Sort, storeUserPictureEditDto.Sort)
                .SetProperty(x => x.PictureAlt, storeUserPictureEditDto.PictureAlt)
                .SetProperty(x => x.PictureTitle, storeUserPictureEditDto.PictureTitle)
                .SetProperty(x => x.IsActive, storeUserPictureEditDto.IsActive)
                .SetProperty(x => x.LastModified, DateTime.Now)
            , cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.StoreUserPictureFailedEdit);
    }

    #endregion

    #region StoreUserPictureDelete
    public async Task<bool> StoreUserPictureDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check=await _context.StorePictures.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.StoreUserPictureFailedDelete);
    }
    #endregion

    #region StoreUserPictureExistAsync
    public async Task<bool> StoreUserPictureExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.StorePictures.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.StoreUserPictureNotFound);
        return true;
    }
    #endregion
}