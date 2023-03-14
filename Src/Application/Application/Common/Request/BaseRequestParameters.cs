#region UsingAndNamespace

using Application.Common.Enums;
using Application.Common.Request.Pagination;

namespace Application.Common.Request; 
#endregion

public abstract class BaseRequestParameters:BasePaginationParameters
{
    private string _Search { set; get; }
    public string Search { get=>_Search; set=>_Search= value?.ToLower(); }

    public SortType SortType { get; set; } = SortType.Desc;
    public int Sort { get; set; } = 1;
}