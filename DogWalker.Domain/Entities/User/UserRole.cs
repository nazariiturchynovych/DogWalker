#pragma warning disable CS8618
namespace DogWalker.Domain.Entities.User;

using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; }

    public Role Role { get; set; }
}