using Application.Common.Enums;
using Application.Enums;
using Domain.Enums;
namespace Application.Dto.User;

public class UserSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Id { get; set; }
    public PhoneConfirmType? PhoneNumberConfirmed { get; set; } = PhoneConfirmType.NotImportant;
    public string? SearchPhoneNumber { get; set; }
    public string? SearchUserName { get; set; }
    public SortType SortType { get; set; } = SortType.Desc;
    public RoleType RoleType { get; set; } = RoleType.NotImportant;

    public UserSearchDto(int pageIndex, int pageSize, string id, PhoneConfirmType? phoneNumberConfirmed, string searchPhoneNumber, string searchUserName, SortType sortType, RoleType roleType)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Id = id;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        SearchPhoneNumber = searchPhoneNumber;
        SearchUserName = searchUserName;
        SortType = sortType;
        RoleType = roleType;
    }

    public UserSearchDto()
    {
        
    }
}