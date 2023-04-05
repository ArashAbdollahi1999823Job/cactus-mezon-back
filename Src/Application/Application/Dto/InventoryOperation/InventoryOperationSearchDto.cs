using Application.Common.Enums;
using Domain.Enums;
namespace Application.Dto.InventoryOperation;
public class InventoryOperationSearchDto
{
    public long Id { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public long Price{ get; set; }
    public int Count { get; set; } = -1;
    public InventoryOperationType InventoryOperationType { get; set; } = InventoryOperationType.NotImportant;
    public long ProductId { get; set; }
    public long InventoryId { get; set; }
    public SortType SortType { get; set; } = SortType.Desc;
    public long StoreId { get; set; }

    public InventoryOperationSearchDto(long id, int pageIndex, int pageSize, long price, int count, InventoryOperationType inventoryOperationType, long productId, long inventoryId, SortType sortType, long storeId)
    {
        Id = id;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Price = price;
        Count = count;
        InventoryOperationType = inventoryOperationType;
        ProductId = productId;
        InventoryId = inventoryId;
        SortType = sortType;
        StoreId = storeId;
    }

    public InventoryOperationSearchDto()
    {
    }
}