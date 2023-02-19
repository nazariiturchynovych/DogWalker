namespace DogWalker.Api.Application.ServiceConfiguration;

using Microsoft.AspNetCore.Identity;

public static class ServiceConfiguration
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        });
    }
}