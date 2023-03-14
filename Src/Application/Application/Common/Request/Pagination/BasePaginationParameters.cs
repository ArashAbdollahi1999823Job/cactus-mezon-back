#region UsingAndNamespace
namespace Application.Common.Request.Pagination; 
#endregion

public class BasePaginationParameters
{
    private const int _MaxPageSize = 50;
    private int _PageIndex { set; get; }=1;
    public int PageIndex
    {
        get => _PageIndex;
        set => _PageIndex = value > _PageIndex ? value : _PageIndex;
    }
    private int _PageSize { set; get; }=15;
    public int PageSize
    {
        get => _PageSize;
        set =>_PageSize= value > _MaxPageSize ? _MaxPageSize : value;
    }
}