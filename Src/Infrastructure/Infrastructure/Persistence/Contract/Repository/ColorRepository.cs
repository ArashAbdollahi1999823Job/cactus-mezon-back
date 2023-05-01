using Application.Common.Messages;
using Application.Dto.Color;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class ColorRepository : IColorRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ColorRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region ColorGetAllAsync
    public async Task<List<ColorDto>> ColorGetAllAsync(ColorSearchDto colorSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Colors.AsQueryable().AsNoTracking();
        if(colorSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.Id == colorSearchDto.Id);
        if(colorSearchDto.ProductId.ToString() !="00000000-0000-0000-0000-000000000000")query = query.Where(x => x.ProductId == colorSearchDto.ProductId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<ColorDto>>(result);
    }
    #endregion

    #region ColorAddAsync
    public async Task<bool> ColorAddAsync(ColorAddDto colorAddDto,CancellationToken cancellationToken)
    {
        var color = new Color(colorAddDto.Name,colorAddDto.Value,colorAddDto.ProductId);
        await _context.Colors.AddAsync(color,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ColorFailedAdd);
    }
    #endregion

    #region ColorGetById
    public async Task<Color> ColorGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (color == null) throw new BadHttpRequestException(ApplicationMessages.ColorNotFound);
        return color;
    }

    #endregion

    #region ColorDelete
    public async Task<bool> ColorDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check=await _context.Colors.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ColorFailedDelete);
    }
    #endregion

    #region ColorExistAsync
    public async Task<bool> ColorExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Colors.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.ColorNotFound);
        return true;
    }
    #endregion
}