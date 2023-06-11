using Application.Common.Messages;
using Application.Dto.Favorite;
using Application.Dto.Product;
using Application.IContracts.IRepository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class FavoriteRepository : IFavoriteRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public FavoriteRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region FavoriteAddAsync
    public async Task<bool> FavoriteAddAsync(FavoriteAddDto favoriteAddDto, CancellationToken cancellationToken)
    {
        var favorite = new UserProductFavorite(favoriteAddDto.UserId, favoriteAddDto.ProductId);
        await _context.UserProductFavorites.AddAsync(favorite, cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.FavoriteFailedAdd);
    }
    #endregion

    #region FavoriteGetAllAsync
    public async Task<List<ProductDto>> FavoriteGetAllAsync(FavoriteSearchDto favoriteSearchDto,
        CancellationToken cancellationToken)
    {
        var productDtos = await _context.Products
            .SelectMany(x => x.UserProductFavorites.Where(x => x.UserId == favoriteSearchDto.UserId).Select(x => x.Product))
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return productDtos;
    }
    #endregion

    #region FavoriteDeleteAsync
    public async Task<bool> FavoriteDeleteAsync(FavoriteDeleteDto favoriteDeleteDto,CancellationToken cancellationToken)
    {
        var check = await _context
            .UserProductFavorites
            .Where(x => x.UserId == favoriteDeleteDto.UserId && x.ProductId == favoriteDeleteDto.ProductId)
            .ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.FavoriteFailedDelete);
    }
    #endregion
    
    #region FavoriteExistNotExceptionAsync
    public async Task<bool> FavoriteExistAsync(FavoriteAddDto favoriteAddDto, CancellationToken cancellationToken)
    {
        var check = await _context
            .UserProductFavorites
            .AsNoTracking()
            .AnyAsync(x => x.UserId== favoriteAddDto.UserId && x.ProductId== favoriteAddDto.ProductId, cancellationToken);
        return check;
    }
    #endregion
}