namespace DogWalker.Infrastructure.Services.CurrentUserService;

using Domain.Enums;

public interface ICurrentUserService
{
    int Id { get; }

    string Email { get; }

    string? Role { get; }

    IEnumerable<string> Roles { get; }
}