#region UsingAndNamespace
using Application.Common.Enums;
using Application.Enums;
namespace Application.Dto.Store;
#endregion
public class StoreSearchDto
{
    public long Id { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public ActiveType ActiveType { get; set; } = ActiveType.NotImportant;
    public string UserId { get; set; } 
    public SortType SortType { get; set; } = SortType.Desc;
    
    public StoreSearchDto(long id, int pageIndex, int pageSize, string name, string phoneNumber, string mobileNumber, ActiveType activeType, string userId, SortType sortType)
    {
        Id = id;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Name = name;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        ActiveType = activeType;
        UserId = userId;
        SortType = sortType;
    }

    public StoreSearchDto()
    {
        
    }
}