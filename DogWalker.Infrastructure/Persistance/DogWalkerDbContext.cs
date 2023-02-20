namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext;

using Domain.Entities.User;
using Domain.Entities.Walker;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class DogWalkerDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public DogWalkerDbContext(DbContextOptions<DogWalkerDbContext> options) : base(options)
    {
    }

    public DbSet<Walker> Walkers { get; set; }

}