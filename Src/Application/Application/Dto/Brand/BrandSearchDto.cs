using Application.Common.Enums;

namespace Application.Dto.Brand;

public class BrandSearchDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SortType SortType { get; set; } = SortType.Desc;


    public BrandSearchDto(int pageIndex, int pageSize, Guid id, string name)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Id = id;
        Name = name;
    }

    public BrandSearchDto()
    {
        
    }
}