﻿using Application.Dto.Base;
using Application.Dto.Type;
using Type = Domain.Entities.ProductEntity.Type;
namespace Application.IContracts.IRepository;
public interface ITypeRepository
{
    public Task<PaginationDto<TypeDto>> TypeGetAllAsync(TypeSearchDto typeSearchDto,CancellationToken cancellationToken);
    public Task<bool> TypeEditAsync(TypeEditDto typeEditDto,CancellationToken cancellationToken);
    public Task<bool> TypeAddAsync(TypeAddDto typeAddDto,CancellationToken cancellationToken);
    public Task<bool> TypeDeleteAsync(long id, CancellationToken cancellationToken);
    public Task<bool> TypeExistAsync(long id, CancellationToken cancellationToken);
    public Task<Type> TypeGetByIdAsync(long id,CancellationToken cancellationToken);
}