using Application.Common.Messages;
using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.PictureEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class TypePictureRepository : ITypePictureRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TypePictureRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region TypePictureGetAllAsync
    public async Task<List<TypePictureDto>> TypePictureGetAllAsync(TypePictureSearchDto typePictureSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.TypePictures.Include(x => x.Type).AsQueryable();
        if(typePictureSearchDto.Id>0)query = query.Where(x => x.Id == typePictureSearchDto.Id);
        if(typePictureSearchDto.TypeId>0)query = query.Where(x => x.TypeId == typePictureSearchDto.TypeId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<TypePictureDto>>(result);
    }
    #endregion

    #region TypePictureAddAsync
    public async Task<bool> TypePictureAddAsync(TypePictureAddDto typePictureAddDto,CancellationToken cancellationToken)
    {
        var typePicture = new TypePicture(typePictureAddDto.PictureTitle, typePictureAddDto.PictureAlt,
            typePictureAddDto.PictureUrlString, typePictureAddDto.Sort, typePictureAddDto.TypeId);
        await _context.TypePictures.AddAsync(typePicture,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedAdd);
    }
    #endregion

    #region TypePictureGetById

    public async Task<TypePicture> TypePictureGetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var typePicture = await _context.TypePictures.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (typePicture == null) throw new BadHttpRequestException(ApplicationMessages.TypePictureNotFound);
        return typePicture;
    }

    #endregion

    #region TypePictureEditAsync
    public async Task<bool> TypePictureEditAsync(TypePictureEditDto typePictureEditDto,
        CancellationToken cancellationToken)
    {
        var check = await _context.TypePictures.Where(x => x.Id == typePictureEditDto.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Sort, typePictureEditDto.Sort)
                .SetProperty(x => x.PictureAlt, typePictureEditDto.PictureAlt)
                .SetProperty(x => x.PictureTitle, typePictureEditDto.PictureTitle)
                .SetProperty(x => x.IsActive, typePictureEditDto.IsActive)
                .SetProperty(x => x.LastModified, DateTime.Now)
            , cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedEdit);
    }

    #endregion

    #region TypePictureDelete
    public async Task<bool> TypePictureDeleteAsync(long id, CancellationToken cancellationToken)
    {
        var check=await _context.TypePictures.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypePictureFailedDelete);
    }
    #endregion

    #region TypePictureExistAsync
    public async Task<bool> TypePictureExistAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.TypePictures.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.TypePictureNotFound);
        return true;
    }

    #endregion
}