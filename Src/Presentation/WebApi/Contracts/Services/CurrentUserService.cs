#region UsingAndNamespace

using Application.IContracts.IServices;
using WebApi.Extensions;

namespace WebApi.Contracts.Services;
#endregion
public class CurrentUserService:ICurrentUserService
{
    #region CtorAndInjection
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion

    public string Id => _httpContextAccessor.HttpContext.User.GetUserId() ?? string.Empty;
    public string PhoneNumber => _httpContextAccessor.HttpContext.User.GetPhoneNumber() ?? string.Empty;
}