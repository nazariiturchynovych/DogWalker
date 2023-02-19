namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Api.Application.Constants;
using Domain.Entities.User;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.Property(r => r.RoleType).IsRequired();

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);

        builder.HasData(
            new Role()
            {
                RoleType = RoleType.Admin,
                Name = RoleType.Admin.ToString(),
                Id = 1
            },
            new Role()
            {
                RoleType = RoleType.Walker,
                Name = RoleType.Walker.ToString(),
                Id = 2,
            },
            new Role()
            {
                RoleType = RoleType.DogFamily,
                Name = RoleType.DogFamily.ToString(),
                Id = 3
            });
    }
}