namespace DogWalker.Infrastructure.Services.CurrentUserService;

using System.Security.Claims;
using Domain.Enums;
using Extensions;
using Microsoft.AspNetCore.Http;

public class CurrentUserService : ICurrentUserService
{
    private static readonly NullReferenceException Exception = new($"{nameof(ClaimsPrincipal)} fail parsing");
    private readonly IHttpContextAccessor _httpAccessor;
    private int _id;
    private string? _email;
    private string? _role;
    private IEnumerable<string>? _roles;

    public CurrentUserService(
        IHttpContextAccessor httpAccessor)
    {
        _httpAccessor = httpAccessor;
    }

    public int Id
    {
        get
        {
            if (_id > 0)
                return _id;

            var id = _httpAccessor
                .HttpContext?
                .User
                .GetId() ?? throw Exception;

            return _id = id;
        }
    }

    public string Email =>
        _email ??= _httpAccessor
            .HttpContext?
            .User
            .GetEmail() ?? throw Exception;

    public string? Role => _role ??= Roles.SingleOrDefault();

    public IEnumerable<string> Roles =>
        _roles ??= _httpAccessor
            .HttpContext?
            .User
            .GetRoles() ?? throw Exception;
}