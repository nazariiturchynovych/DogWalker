#pragma warning disable CS8618
namespace DogWalker.Domain.Entities.User;

using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityUserRole<int>
{
    public virtual User User { get; set; }

    public virtual Role Role { get; set; }
}