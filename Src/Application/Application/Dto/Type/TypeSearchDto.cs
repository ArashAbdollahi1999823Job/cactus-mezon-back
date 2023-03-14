using Application.Common.Enums;
using Application.Enums;
namespace Application.Dto.Type;
public class TypeSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public long Id { get; set; } = 0;
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;
    public string Name { get; set; } = null;
    public long ParentTypeId { get; set; } = -1;
    public SortType SortType { get; set; } = SortType.Desc;

    public TypeSearchDto(int pageIndex, int pageSize, long id, ActiveType isActive, string name, long parentTypeId, SortType sortType)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Id = id;
        IsActive = isActive;
        Name = name;
        ParentTypeId = parentTypeId;
        SortType = sortType;
    }

    public TypeSearchDto()
    {
        
    }
}