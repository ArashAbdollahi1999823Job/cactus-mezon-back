﻿using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Off;
using Application.Dto.Product;
using Application.Dto.ProductDto;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Entities.StoreEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class OffRepository:IOffRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public OffRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region OffGetAllAsync
    public async Task<List<OffDto>> OffGetAllAsync(OffSearchDto offSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Offs.AsQueryable();
        if (offSearchDto.Id > 0) query = query.Where(x => x.Id ==offSearchDto.Id);
        if (offSearchDto.StoreId > 0) query = query.Where(x => x.StoreId ==offSearchDto.StoreId);

        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<OffDto>>(result);
       
    }
    #endregion
    
    #region OffAddAsync
    public async Task<bool> OffAddAsync(OffAddDto offAddDto, CancellationToken cancellationToken)
    {
        var off = new Off(offAddDto.Name,offAddDto.Description,offAddDto.OffPercent,offAddDto.StartDate,offAddDto.EndDate,offAddDto.StoreId);
        await _context.Offs.AddAsync(off, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.OffAddFailed);
    }
    #endregion
    
    #region OffEditAsync
    public async Task<bool> OffEditAsync(OffEditDto offEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.Offs
            .Where(x => x.Id == offEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , offEditDto.Name)
                    .SetProperty(x=>x.Description,offEditDto.Description)
                    .SetProperty(x=>x.StartDate,offEditDto.StartDate)
                    .SetProperty(x=>x.EndDate,offEditDto.EndDate)
                    .SetProperty(x=>x.OffPercent,offEditDto.OffPercent)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.OffEditFailed);
    }
    #endregion
    
    #region OffExistAsync
    public async Task<bool> OffExistAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.Offs.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.OffNotFound);
        return true;
    }
    #endregion
    
    #region OffDeleteAsync
    public async Task<bool> OffDeleteAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.Offs.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.OffDeleteFailed);
    }
    #endregion
}