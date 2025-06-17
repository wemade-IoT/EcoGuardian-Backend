using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcoGuardian_Backend.Shared.Interfaces.Filters;

public class AuthorizeFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var currentRole = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
        var allowRoles = context.ActionDescriptor.EndpointMetadata
            .OfType<AuthorizeFilterAttribute>()
            .SelectMany(x => x.Roles)
            .ToList();

        if (currentRole != null && allowRoles.Contains(currentRole.Value))
        {
            // User is authorized, do nothing
            return;
        }
        
        // User is not authorized, set the result to Unauthorized
        context.Result = new ForbidResult();

    }
}