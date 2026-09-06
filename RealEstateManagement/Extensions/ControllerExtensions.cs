using System.Security.Claims;

namespace RealEstateManagement.Extensions
{
    public static class ControllerExtensions
    {
        public static string? GetIdentityUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
