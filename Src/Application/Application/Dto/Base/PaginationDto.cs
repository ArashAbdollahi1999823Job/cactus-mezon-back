#region UsingAndNamespace

namespace Application.Dto.Base;
#endregion

public class PaginationDto<T> where T:class
{
    #region Ctor

    public PaginationDto(int pageIndex, int pageSize, int count, IEnumerable<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }

    #endregion
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public IEnumerable<T> Data { get; set; }
}