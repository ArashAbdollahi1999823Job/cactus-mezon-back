﻿using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Color;
using Application.Dto.InventoryOperation;
using Application.Dto.Product;
using Application.Dto.ProductItem;
using Application.Dto.ProductPicture;
using Application.Enums;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Enums;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class ProductRepository:IProductRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IProductPictureRepository _productPictureRepository;
    private readonly IFileUploader _fileUploader;
    private readonly IInventoryOperationRepository _inventoryOperationRepository;
    private readonly IColorRepository _colorRepository;
    private readonly IProductItemRepository _productItemRepository;
    public ProductRepository(ApplicationDbContext context, IMapper mapper, IProductPictureRepository productPictureRepository, IFileUploader fileUploader, IInventoryOperationRepository inventoryOperationRepository, IColorRepository colorRepository, IProductItemRepository productItemRepository)
    {
        _context = context;
        _mapper = mapper;
        _productPictureRepository = productPictureRepository;
        _fileUploader = fileUploader;
        _inventoryOperationRepository = inventoryOperationRepository;
        _colorRepository = colorRepository;
        _productItemRepository = productItemRepository;
    }
    #endregion

    #region ProductGetAllAsync
    public async Task<PaginationDto<ProductDto>> ProductGetAllAsync(ProductSearchDto productSearchDto, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsQueryable();
        if (!String.IsNullOrEmpty(productSearchDto.Name)) query = query.Where(x => x.Name.Contains(productSearchDto.Name));
        if (!String.IsNullOrEmpty(productSearchDto.Slug)) query = query.Where(x => x.Slug.Contains(productSearchDto.Slug));
        if (productSearchDto.InventoryId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.InventoryId == productSearchDto.InventoryId);
        if (productSearchDto.BrandId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.BrandId == productSearchDto.BrandId);
        if (productSearchDto.Off != -1) query = query.Where(x => x.Off.OffPercent >= productSearchDto.Off);
        if (productSearchDto.Price != 0) query = query.Where(x => x.Price == productSearchDto.Price);
        if (productSearchDto.StoreId.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Inventory.StoreId == productSearchDto.StoreId);

        if (productSearchDto.IsActive != 0)
        {
            if (productSearchDto.IsActive == ActiveType.Active) query = query.Where(x => x.IsActive == true);
            if (productSearchDto.IsActive == ActiveType.NotActive) query = query.Where(x => x.IsActive == false);
        }
        if (productSearchDto.Id.ToString() !="00000000-0000-0000-0000-000000000000") query = query.Where(x => x.Id ==productSearchDto.Id);
        if (productSearchDto.TypeId.ToString() !="00000000-0000-0000-0000-000000000001")
        {
            if (productSearchDto.TypeId.ToString() !="00000000-0000-0000-0000-000000000000") query = query
                .Where(x => x.Type.Id == productSearchDto.TypeId
                            ||x.Type.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.Id==productSearchDto.TypeId
                            || x.Type.ParentType.ParentType.ParentType.Id==productSearchDto.TypeId);
        }

        var count = await query.CountAsync(cancellationToken);
        if (productSearchDto.SortType == SortType.Desc)
        {
            query = query.OrderByDescending(x => x.Id);
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }
        query = query
            .Include(x=>x.Type)
            .Include(x=>x.Brand)
            .Include(x=>x.Off)
            .Include(x=>x.Colors)
            .Include(x=>x.ProductItems)
            .Include(x=>x.Inventory)
            .ThenInclude(x=>x.Store)
            .ThenInclude(x=>x.User);
        var result = await query.Skip((productSearchDto.PageIndex - 1) * productSearchDto.PageSize).Take(productSearchDto.PageSize).ToListAsync(cancellationToken);
        var data = _mapper.Map<List<ProductDto>>(result);
        return new PaginationDto<ProductDto>(productSearchDto.PageIndex, productSearchDto.PageSize, count, data);
    }
    #endregion
    
    #region ProductAddAsync
    public async Task<bool> ProductAddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
    {
        var product = new Product(productAddDto.Name,productAddDto.Slug,productAddDto.Description,
            productAddDto.MetaDescription,productAddDto.Price,productAddDto.Summary,productAddDto.InventoryId
            ,productAddDto.TypeId,productAddDto.BrandId.ToString() =="00000000-0000-0000-0000-000000000000" ? null : productAddDto.BrandId);
        await _context.Products.AddAsync(product, cancellationToken);
        var check =await _context.SaveChangesAsync(cancellationToken);
        if (check >0)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.ProductAddFailed);
    }
    #endregion
    
    #region ProductEditAsync
    public async Task<bool> ProductEditAsync(ProductEditDto productEditDto, CancellationToken cancellationToken)
    {
        var check = await _context.Products
            .Where(x => x.Id == productEditDto.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Name , productEditDto.Name)
                    .SetProperty(x => x.Price , productEditDto.Price)
                    .SetProperty(x => x.Slug , productEditDto.Slug)
                    .SetProperty(x=>x.Description,productEditDto.Description)
                    .SetProperty(x=>x.MetaDescription,productEditDto.MetaDescription)
                    .SetProperty(x=>x.Summary,productEditDto.Summary)
                    .SetProperty(x=>x.IsActive,productEditDto.IsActive)
                    .SetProperty(x=>x.LastModified,DateTime.Now)
                    .SetProperty(x=>x.TypeId,productEditDto.TypeId)
                    .SetProperty(x=>x.InventoryId,productEditDto.InventoryId)
                    .SetProperty(x=>x.BrandId,productEditDto.BrandId.ToString() =="00000000-0000-0000-0000-000000000000" ? null:productEditDto.BrandId)
                    .SetProperty(x=>x.OffId,productEditDto.OffId.ToString() =="00000000-0000-0000-0000-000000000000" ? null:productEditDto.OffId)

                , cancellationToken: cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
    }
    #endregion
    
    #region ProductExistAsync
    public async Task<bool> ProductExistAsync(Guid id, CancellationToken cancellationToken)
    {
        var check = await _context.Products.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.ProductNotFound);
        return true;
    }
    #endregion
    
    #region ProductDeleteAsync
    public async Task<bool> ProductDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        
        #region InventoryOperationDelete
        var inventoryOperationSearchDto = new InventoryOperationSearchDto(
            new Guid("00000000-0000-0000-0000-000000000000"), 1, 1000, 0, -1, InventoryOperationType.NotImportant,
            id, new Guid("00000000-0000-0000-0000-000000000000"), SortType.Desc,
            new Guid("00000000-0000-0000-0000-000000000000"));
        var inventoryOperation =
            await _inventoryOperationRepository.InventoryOperationGetAllAsync(inventoryOperationSearchDto,
                cancellationToken);
        
        foreach (var inventoryOperationDto in inventoryOperation.Data)
        {
            await _inventoryOperationRepository.InventoryOperationDeleteAsync(inventoryOperationDto.Id, cancellationToken);
        }
        #endregion

        #region ColorDelete
        var colors = await _colorRepository.ColorGetAllAsync(
            new ColorSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), id), cancellationToken);
        colors.ForEach(x =>
        {
            _colorRepository.ColorDeleteAsync(x.Id, cancellationToken);
        });
        #endregion

        #region ItemDelete
        var items = await _productItemRepository.ProductItemGetAllAsync(
            new ProductItemSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), id), cancellationToken);
        
        items.ForEach(x =>
        {
            _productItemRepository.ProductItemDeleteAsync(x.Id, cancellationToken);
        });
        #endregion

        #region ProductPictureDelete
        var productPictureSearchDto = new ProductPictureSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), id, 1, 0, 100);
        var productPictures = await _productPictureRepository.ProductPictureGetAllAsync(productPictureSearchDto,cancellationToken);
        productPictures.ForEach(x =>
        {
            _fileUploader.Delete(x.PictureUrl);
            _productPictureRepository.ProductPictureDeleteAsync(x.Id, cancellationToken);
        });
        #endregion
        
        var check = await _context.Products.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ProductDeleteFailed);
    }
    #endregion
    
    #region ProductGetByIdAsync
    public async Task<Product> ProductGetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        if (product == null) throw new NotFoundEntityException(ApplicationMessages.ProductNotFound);
        return product;
    }



    #endregion

    #region ProductChangeCountAsync

    public async Task<bool> ProductChangeCountAsync(int count, string inventoryOperationType, Guid productId,
        CancellationToken cancellationToken)
    {
        if (inventoryOperationType == "1" || inventoryOperationType == "4")
        {
            var check = await _context.Products
                .Where(x => x.Id == productId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count+count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
        else
        {
            var check = await _context.Products
                .Where(x => x.Id == productId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count-count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
                
                
    }

    #endregion
    
    #region ProductChangeCountDeleteOperationAsync

    public async Task<bool> ProductChangeCountDeleteOperationAsync(InventoryOperationDto inventoryOperationDto,CancellationToken cancellationToken)
    {
        if (inventoryOperationDto.InventoryOperationType == "1" || inventoryOperationDto.InventoryOperationType == "4")
        {
            var check = await _context.Products
                .Where(x => x.Id == inventoryOperationDto.ProductId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count-inventoryOperationDto.Count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
        else
        {
            var check = await _context.Products
                .Where(x => x.Id ==inventoryOperationDto.ProductId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Count,a=>a.Count+inventoryOperationDto.Count), cancellationToken);
            if (check > 0) return true;
            throw new BadRequestEntityException(ApplicationMessages.ProductEditFailed);
        }
                
                
    }

    #endregion
}