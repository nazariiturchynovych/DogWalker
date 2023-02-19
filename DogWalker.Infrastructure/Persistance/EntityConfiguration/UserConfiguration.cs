namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.DogFamily;
using Domain.Entities.JobRequest.Documents;
using Domain.Entities.User;
using Domain.Entities.Walker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder
            .HasIndex(x => x.NormalizedEmail)
            .IsUnique();

        builder.HasOne(u => u.PersonalIdentifier)
            .WithOne(pi => pi.User)
            .HasForeignKey<PersonalIdentifier>(pi => pi.UserId );

        builder.HasOne(u => u.Walker)
            .WithOne(w => w.User)
            .HasForeignKey<Walker>(w => w.UserId);

        builder.HasOne(u => u.DogFamily)
            .WithOne(df => df.User)
            .HasForeignKey<DogFamily>(df => df.UserId);

        builder.HasMany(u => u.ChatMembers)
            .WithOne(cm => cm.User)
            .HasForeignKey(um => um.UserId);

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);


    }
}