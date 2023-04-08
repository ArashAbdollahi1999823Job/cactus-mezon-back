using Application.Common.Messages;
using Application.Dto.ProductPicture;
using Application.Dto.TypePicture;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.PictureEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class ProductPictureRepository : IProductPictureRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductPictureRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region ProductPictureGetAllAsync
    public async Task<List<ProductPictureDto>> ProductPictureGetAllAsync(ProductPictureSearchDto productPictureSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.ProductPictures.Include(x => x.Product).AsQueryable();
        if(productPictureSearchDto.Id>0)query = query.Where(x => x.Id == productPictureSearchDto.Id);
        if(productPictureSearchDto.Sort>0)query = query.Where(x => x.Sort == productPictureSearchDto.Sort);
        if(productPictureSearchDto.ProductId>0)query = query.Where(x => x.ProductId == productPictureSearchDto.ProductId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<ProductPictureDto>>(result);
    }
    #endregion

    #region ProductPictureAddAsync
    public async Task<bool> ProductPictureAddAsync(ProductPictureAddDto productPictureAddDto,CancellationToken cancellationToken)
    {
        var productPicture = new ProductPicture(productPictureAddDto.PictureTitle, productPictureAddDto.PictureAlt, productPictureAddDto.PictureUrlString, productPictureAddDto.Sort, productPictureAddDto.ProductId);
        await _context.ProductPictures.AddAsync(productPicture,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductPictureAddFailed);
    }
    #endregion

    #region ProductPictureGetById
    public async Task<ProductPicture> ProductPictureGetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var productPicture = await _context.ProductPictures.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (productPicture == null) throw new BadHttpRequestException(ApplicationMessages.ProductPictureNotFound);
        return productPicture;
    }
    #endregion

    #region ProductPictureEditAsync
    public async Task<bool>ProductPictureEditAsync(ProductPictureEditDto productPictureEditDto,
        CancellationToken cancellationToken)
    {
        var check = await _context.ProductPictures.Where(x => x.Id == productPictureEditDto.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Sort, productPictureEditDto.Sort)
                .SetProperty(x => x.PictureAlt, productPictureEditDto.PictureAlt)
                .SetProperty(x => x.PictureTitle, productPictureEditDto.PictureTitle)
                .SetProperty(x => x.IsActive, productPictureEditDto.IsActive)
                .SetProperty(x => x.LastModified, DateTime.Now)
            , cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductPictureEditFailed);
    }
    #endregion

    #region ProductPictureDelete
    public async Task<bool> ProductPictureDeleteAsync(long id, CancellationToken cancellationToken)
    {
        var check=await _context.ProductPictures.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductPictureDeleteFailed);
    }
    #endregion

    #region ProductPictureExistAsync
    public async Task<bool> ProductPictureExistAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.ProductPictures.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.ProductPictureNotFound);
        return true;
    }
    #endregion
}