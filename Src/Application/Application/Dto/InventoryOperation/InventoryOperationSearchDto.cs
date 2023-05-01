using Application.Common.Enums;
using Domain.Enums;
namespace Application.Dto.InventoryOperation;
public class InventoryOperationSearchDto
{
    public Guid Id { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public long Price{ get; set; }
    public int Count { get; set; } = -1;
    public InventoryOperationType InventoryOperationType { get; set; } = InventoryOperationType.NotImportant;
    public Guid ProductId { get; set; }
    public Guid InventoryId { get; set; }
    public SortType SortType { get; set; } = SortType.Desc;
    public Guid StoreId { get; set; }

    public InventoryOperationSearchDto(Guid id, int pageIndex, int pageSize, long price, int count, InventoryOperationType inventoryOperationType,
        Guid productId, Guid inventoryId, SortType sortType, Guid storeId)
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