using System.Security.Claims;
namespace WebApi.Extensions;
public static class ClaimsPrincipleExtension
{
    public static string? GetUserId(this ClaimsPrincipal principal)
    {
        return principal.FindFirst("Id")?.Value;
    }

    public static string? GetPhoneNumber(this ClaimsPrincipal principal)
    {
        return principal.FindFirst("PhoneNumber")?.Value;
    }
}