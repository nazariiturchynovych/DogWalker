// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618
namespace DogWalker.Domain.Entities.User;

using Base;
using Chat;
using DogFamily;
using Immage;
using JobRequest.Documents;
using Microsoft.AspNetCore.Identity;
using Walker;

public class User : IdentityUser<int>, IEntity
{
    public PersonalIdentifier PersonalIdentifier { get; set; }
    public DogFamily DogFamily { get; set; }
    public Walker Walker { get; set; }
    public bool GoogleAuth { get; set; }

    public bool FacebookAuth { get; set; }

    public bool InstagramAuth { get; set; }

    public ICollection<ChatMember> ChatMembers { get; set; }
        = new List<ChatMember>();

    public ICollection<UserRole> UserRoles { get; set; }
        = new List<UserRole>();
}