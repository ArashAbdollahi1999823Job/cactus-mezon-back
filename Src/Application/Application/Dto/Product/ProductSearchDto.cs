using Application.Common.Enums;
using Application.Enums;
namespace Application.Dto.ProductDto;
public class ProductSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public long Id { get; set; }
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;
    public string Name { get; set; }
    public string Slug { get; set; }
    public decimal Price { get; set; }
    public long InventoryId { get; set; } = 0;
    public long TypeId { get; set; } = -1;
    public long BrandId { get; set; } = 0;
    public int Off { get; set; } = -1;
    public SortType SortType { get; set; } = SortType.Desc;
    public long StoreId { get; set; } = 0;

    public ProductSearchDto(int pageIndex, int pageSize, long id, ActiveType isActive, string name, string slug
        , decimal price, long inventoryId, long typeId, long brandId, int off, SortType sortType,long storeId)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Id = id;
        IsActive = isActive;
        Name = name;
        Slug = slug;
        Price = price;
        InventoryId = inventoryId;
        TypeId = typeId;
        BrandId = brandId;
        Off = off;
        SortType = sortType;
        StoreId = storeId;
    }

    public ProductSearchDto()
    {
        
    }
}