using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Dto.ProductDto;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class BrandRepository:IBrandRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public BrandRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region BrandGetAllAsync
    public async Task<PaginationDto<BrandDto>> BrandGetAllAsync(BrandSearchDto brandSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Brands.AsQueryable();
        if (!String.IsNullOrEmpty(brandSearchDto.Name)) query = query.Where(x => x.Name.Contains(brandSearchDto.Name));
        if (brandSearchDto.Id > 0) query = query.Where(x => x.Id ==brandSearchDto.Id);
        var count = await query.CountAsync(cancellationToken);
        if (brandSearchDto.SortType == SortType.Desc)
        {
            query = query.OrderByDescending(x => x.Id);
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }
        var result = await query.Skip((brandSearchDto.PageIndex - 1) * brandSearchDto.PageSize).Take(brandSearchDto.PageSize).ToListAsync(cancellationToken);
        var data = _mapper.Map<List<BrandDto>>(result);
        return new PaginationDto<BrandDto>(brandSearchDto.PageIndex, brandSearchDto.PageSize, count, data);
    }
    #endregion
    
    #region BrandAddAsync
    public async Task<bool> BrandAddAsync(BrandAddDto brandAddDto, CancellationToken cancellationToken)
    {
        var brand = new Brand(brandAddDto.Name,brandAddDto.Description,brandAddDto.MetaDescription,brandAddDto.Summary);
        await _context.Brands.AddAsync(brand, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.BrandAddFailed);
    }
    #endregion
    
    #region BrandEditAsync
    public async Task<bool> BrandEditAsync(BrandEditDto brandEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.Brands
            .Where(x => x.Id == brandEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , brandEditDto.Name)
                    .SetProperty(x=>x.Description,brandEditDto.Description)
                    .SetProperty(x=>x.MetaDescription,brandEditDto.MetaDescription)
                    .SetProperty(x=>x.Summary,brandEditDto.Summary)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.BrandEditFailed);
    }
    #endregion
    
    #region BrandExistAsync
    public async Task<bool> BrandExistAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.Brands.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.BrandNotFound);
        return true;
    }
    #endregion
    
    #region BrandDeleteAsync
    public async Task<bool> BrandDeleteAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.Brands.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.BrandDeleteFailed);
    }
    #endregion
}