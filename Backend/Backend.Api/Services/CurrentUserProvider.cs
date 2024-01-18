using System.Security.Claims;
using Backend.Application.Common;
using Backend.Application.Common.Models;

namespace Backend.Api.Services;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor): ICurrentUserProvider
{
    public CurrentUser GetCurrentUser()
    {
        var id = GetClaimValues("id")
            .Select(Guid.Parse)
            .First();
        
        var permissions = GetClaimValues("permissions");
        var roles = GetClaimValues(ClaimTypes.Role);

        return new CurrentUser(Id: id, Permissions: permissions, Roles: roles);
    }
    
    private IReadOnlyList<string> GetClaimValues(string claimType)
    {
        return httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();
    }
}