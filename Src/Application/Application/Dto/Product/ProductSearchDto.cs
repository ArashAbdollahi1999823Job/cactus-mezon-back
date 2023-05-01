using Application.Common.Enums;
using Application.Enums;

namespace Application.Dto.Product;
public class ProductSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid Id { get; set; }
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;
    public string Name { get; set; }
    public string Slug { get; set; }
    public decimal Price { get; set; }
    public Guid InventoryId { get; set; }
    public Guid TypeId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public Guid BrandId { get; set; }
    public int Off { get; set; } = -1;
    public SortType SortType { get; set; } = SortType.Desc;
    public Guid StoreId { get; set; }
    public bool User { get; set; } = false;

    public ProductSearchDto(int pageIndex, int pageSize, Guid id, ActiveType isActive, string name, string slug
        , decimal price, Guid inventoryId, Guid typeId, Guid brandId, int off, SortType sortType,Guid storeId, bool user)
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
        User = user;
    }

    public ProductSearchDto()
    {
    }
}