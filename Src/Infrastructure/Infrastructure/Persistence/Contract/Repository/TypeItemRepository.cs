using Application.Common.Messages;
using Application.Dto.TypeItem;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;

public class TypeItemRepository : ITypeItemRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public TypeItemRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region TypeItemGetAllAsync
    public async Task<List<TypeItemDto>> TypeItemGetAllAsync(TypeItemSearchDto typeItemSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.TypeItems.AsQueryable().AsNoTracking();
        if(typeItemSearchDto.Id>0)query = query.Where(x => x.Id == typeItemSearchDto.Id);
        if(typeItemSearchDto.TypeId>0)query = query.Where(x => x.TypeId == typeItemSearchDto.TypeId);
        var result = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<TypeItemDto>>(result);
    }
    #endregion

    #region TypeItemAddAsync
    public async Task<bool> TypeItemAddAsync(TypeItemAddDto typeItemAddDto,CancellationToken cancellationToken)
    {
        var typeItem = new TypeItem(typeItemAddDto.Name,typeItemAddDto.TypeId);
        await _context.TypeItems.AddAsync(typeItem,cancellationToken);
        var check = await _context.SaveChangesAsync(cancellationToken);
        if (check > 0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.TypeItemFailedAdd);
    }
    #endregion

    #region TypeItemGetById
    public async Task<TypeItem> TypeItemGetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var typeItem = await _context.TypeItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (typeItem == null) throw new BadHttpRequestException(ApplicationMessages.TypeItemNotFound);
        return typeItem;
    }

    #endregion

    #region TypeItemDelete
    public async Task<bool> TypeItemDeleteAsync(long id, CancellationToken cancellationToken)
    {
        var check=await _context.TypeItems.Where(x=>x.Id==id).ExecuteDeleteAsync(cancellationToken);
        if (check >0) return true;
        throw new BadRequestEntityException(ApplicationMessages.TypeItemFailedDelete);
    }
    #endregion

    #region TypeItemExistAsync
    public async Task<bool> TypeItemExistAsync(long id, CancellationToken cancellationToken)
    {
        var check = await _context.TypeItems.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.TypeItemNotFound);
        return true;
    }
    #endregion
}