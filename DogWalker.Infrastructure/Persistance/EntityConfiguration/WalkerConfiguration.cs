namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.Immage;
using Domain.Entities.Walker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WalkerConfiguration : IEntityTypeConfiguration<Walker>
{
    public void Configure(EntityTypeBuilder<Walker> builder)
    {
        builder.ToTable("Walkers");

        builder.HasMany(w => w.Jobs)
            .WithOne(j => j.Walker)
            .HasForeignKey(j => j.WalkerId);

        builder.HasOne(w => w.Image)
            .WithOne(i => i.Walker)
            .HasForeignKey<Image>(i => i.WalkerId)
            .IsRequired(false);
    }
}