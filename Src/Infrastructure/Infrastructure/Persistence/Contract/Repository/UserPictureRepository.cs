using Application.Common.Messages;
using Application.Dto.UserPicture;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.PictureEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class UserPictureRepository : IUserPictureRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserPictureRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region UserPictureGetAllAsync
    public async Task<UserPictureDto> UserPictureGetAllAsync(UserPictureSearchDto userPictureSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.UserPictures.Include(x => x.User).AsQueryable();
        if(userPictureSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.Id == userPictureSearchDto.Id);
        if(!string.IsNullOrEmpty(userPictureSearchDto.UserId))query = query.Where(x => x.UserId == userPictureSearchDto.UserId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<UserPictureDto>(result.FirstOrDefault());
    }
    #endregion

    #region UserPictureAddAsync
    public async Task<bool> UserPictureAddAsync(UserPictureAddDto userPictureAddDto,CancellationToken cancellationToken)
    {
        var userPicture = new UserPicture(userPictureAddDto.PictureUrlString, userPictureAddDto.UserId);
        await _context.UserPictures.AddAsync(userPicture,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.UserPictureFailedAdd);
    }
    #endregion

    #region UserPictureGetById

    public async Task<UserPicture> UserPictureGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var userPicture = await _context.UserPictures.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (userPicture == null) throw new BadHttpRequestException(ApplicationMessages.UserPictureNotFound);
        return userPicture;
    }

    #endregion

    #region UserPictureDelete
    public async Task<bool> UserPictureDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check=await _context.UserPictures.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.UserPictureFailedDelete);
    }
    #endregion

    #region UserPictureExistAsync
    public async Task<bool> UserPictureExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.UserPictures.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.UserPictureNotFound);
        return true;
    }

    #endregion
}