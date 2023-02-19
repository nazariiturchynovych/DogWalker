namespace DogWalker.Infrastructure.Extensions;

using System.Security.Claims;

public static class UserClaimPrincipalExtensions
{
    private static readonly NullReferenceException Exception = new($"{nameof(ClaimsPrincipal)} fail parsing");

    public static int GetId(this ClaimsPrincipal? claimsPrincipal)
    {
        var id = int.Parse(claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw Exception);

        if (id < 1)
            throw Exception;

        return id;
    }

    public static string GetEmail(this ClaimsPrincipal? claimsPrincipal)
        => claimsPrincipal?.FindFirst(ClaimTypes.Email)?.Value ?? throw Exception;

    public static IEnumerable<string> GetRoles(this ClaimsPrincipal? claimsPrincipal)
        => claimsPrincipal?.FindAll(ClaimTypes.Role).Select(c => c.Value) ?? throw Exception;

    public static string GetRole(this ClaimsPrincipal? claimsPrincipal)
        => claimsPrincipal.GetRoles().FirstOrDefault() ?? throw Exception;
}