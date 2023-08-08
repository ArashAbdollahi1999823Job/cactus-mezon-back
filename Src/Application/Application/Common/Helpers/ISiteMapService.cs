namespace Application.Common.Helpers;

public interface ISiteMapService
{
    public void UpdateSiteMap(string urlString, string operation,string freq,string priorityString);
}