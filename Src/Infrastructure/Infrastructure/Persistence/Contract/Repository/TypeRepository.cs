﻿using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Type;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Entities.ProductEntity.Type;
namespace Infrastructure.Persistence.Contract.Repository;
public class TypeRepository : ITypeRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public TypeRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region TypeGetAllAsync
    public async Task<PaginationDto<TypeDto>> TypeGetAllAsync(TypeSearchDto typeSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Types.AsQueryable().AsNoTracking();
        
        if (!String.IsNullOrEmpty(typeSearchDto.Name)) query = query.Where(x => x.Name.Contains(typeSearchDto.Name));
        if (!String.IsNullOrEmpty(typeSearchDto.Slug)) query = query.Where(x => x.Slug==typeSearchDto.Slug);
        if (typeSearchDto.IsActive != 0)
        {
            if (typeSearchDto.IsActive == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (typeSearchDto.IsActive == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        if (typeSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id ==typeSearchDto.Id);
        if (typeSearchDto.ParentTypeId.ToString() !="00000000-0000-0000-0000-000000000001")
        {
            if (typeSearchDto.ParentTypeId.ToString() =="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.ParentTypeId == null);
            if (typeSearchDto.ParentTypeId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.ParentType.Id==typeSearchDto.ParentTypeId 
                                                                          || x.ParentType.ParentType.Id==typeSearchDto.ParentTypeId 
                                                                          || x.ParentType.ParentType.Id==typeSearchDto.ParentTypeId 
                                                                              || x.ParentType.ParentType.ParentType.Id==typeSearchDto.ParentTypeId );
        }

        if (typeSearchDto.JustParentTypeId.ToString() !="00000000-0000-0000-0000-000000000001")
        {
            if (typeSearchDto.ParentTypeId.ToString() =="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.ParentTypeId == null);
            if (typeSearchDto.ParentTypeId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.ParentTypeId == typeSearchDto.JustParentTypeId);
        }
        var count = await query.CountAsync(cancellationToken);
        if (typeSearchDto.SortType == SortType.Desc)
        {
            query = query.OrderByDescending(x => x.Id);
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        query = query.OrderBy(x => x.Sort);
        query = query.Include(x => x.ParentType);
        var result = await query.Skip((typeSearchDto.PageIndex - 1) * typeSearchDto.PageSize).Take(typeSearchDto.PageSize).ToListAsync(cancellationToken);
        var data = _mapper.Map<List<TypeDto>>(result);
        return new PaginationDto<TypeDto>(typeSearchDto.PageIndex, typeSearchDto.PageSize, count, data);
    }
    #endregion

    #region TypeAddAsync
    public async Task<bool> TypeAddAsync(TypeAddDto typeAddDto, CancellationToken cancellationToken)
    {
        var type = new Type(typeAddDto.Name, typeAddDto.Description, typeAddDto.MetaDescription, typeAddDto.Summary,
            typeAddDto.ParentTypeId.ToString() =="00000000-0000-0000-0000-000000000000" ? null : typeAddDto.ParentTypeId,typeAddDto.Slug,typeAddDto.Sort);
        await _context.Types.AddAsync(type, cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypeFailedAdd);
    }
    #endregion

    #region TypeEditAsync
    public async Task<bool> TypeEditAsync(TypeEditDto typeEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.Types
            .Where(x => x.Id == typeEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , typeEditDto.Name)
                    .SetProperty(x=>x.Description,typeEditDto.Description)
                    .SetProperty(x=>x.MetaDescription,typeEditDto.MetaDescription)
                    .SetProperty(x=>x.Summary,typeEditDto.Summary)
                    .SetProperty(x=>x.IsActive,typeEditDto.IsActive)
                    .SetProperty(x=>x.IsDelete,typeEditDto.IsDelete)
                    .SetProperty(x=>x.Slug,typeEditDto.Slug)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                    .SetProperty(x=>x.Sort,typeEditDto.Sort)
                    .SetProperty(x=>x.ParentTypeId,typeEditDto.ParentTypeId.ToString() =="00000000-0000-0000-0000-000000000000" ? null : typeEditDto.ParentTypeId)
                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypeFailedEdit);
    }
    #endregion

    #region TypeGetByIdAsync
    public async Task<Type> TypeGetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        var type = await _context.Types.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (type == null) throw new NotFoundEntityException(ApplicationMessages.TypeNotFound);
        return type;
    }
    #endregion

    #region TypeExistAsync
    public async Task<bool> TypeExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Types.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.TypeNotFound);
        return true;
    }
    #endregion

    #region TypeDeleteAsync
    public async Task<bool> TypeDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Types.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypeFailedDelete);
    }
    #endregion
}