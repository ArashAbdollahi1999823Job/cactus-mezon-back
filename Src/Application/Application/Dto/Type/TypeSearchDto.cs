using Application.Common.Enums;
using Application.Enums;
namespace Application.Dto.Type;
public class TypeSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid Id { get; set; } 
    public string Slug { get; set; }
    public ActiveType IsActive { get; set; } = ActiveType.NotImportant;
    public string Name { get; set; } = null;
    public Guid ParentTypeId { get; set; } =new Guid("00000000-0000-0000-0000-000000000001");
    public Guid JustParentTypeId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public SortType SortType { get; set; } = SortType.Desc;

    public TypeSearchDto(int pageIndex, int pageSize, Guid id, ActiveType isActive, string name, Guid parentTypeId, SortType sortType, string slug, Guid justParentTypeId)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Id = id;
        IsActive = isActive;
        Name = name;
        ParentTypeId = parentTypeId;
        SortType = sortType;
        Slug = slug;
        JustParentTypeId = justParentTypeId;
    }

    public TypeSearchDto()
    {
    }
}