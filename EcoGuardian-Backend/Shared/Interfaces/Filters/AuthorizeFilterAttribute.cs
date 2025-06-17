namespace EcoGuardian_Backend.Shared.Interfaces.Filters;

public class AuthorizeFilterAttribute : Attribute
{
    public string[] Roles { get; }

    public AuthorizeFilterAttribute(params string[] roles)
    {
        Roles = roles;
    }
}