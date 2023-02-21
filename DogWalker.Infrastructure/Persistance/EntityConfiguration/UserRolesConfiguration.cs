namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Api.Application.Constants;
using Domain.Entities.User;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");


        builder
            .HasKey(
                ur => new
                {
                    ur.UserId,
                    ur.RoleId
                });

        builder.HasData(
            new UserRole()
            {
                RoleId = (int) RoleType.Admin,
                UserId = AdminConstant.Id
            });
    }
}