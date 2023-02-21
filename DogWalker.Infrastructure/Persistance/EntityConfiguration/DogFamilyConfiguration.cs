namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.DogFamily;
using Domain.Entities.Immage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DogFamilyConfiguration : IEntityTypeConfiguration<DogFamily>
{
    public void Configure(EntityTypeBuilder<DogFamily> builder)
    {
        builder.ToTable("DogFamilies");

        builder.HasMany(df => df.Dogs)
            .WithOne(d => d.DogFamily)
            .HasForeignKey(d => d.DogFamily);

        builder.HasMany(df => df.Jobs)
            .WithOne(j => j.DogFamily)
            .HasForeignKey(j => j.DogFamilyId);

        builder.HasMany(df => df.JobRequests)
            .WithOne(jr => jr.DogFamily)
            .HasForeignKey(jr => jr.DogFamilyId);

        builder.HasOne(df => df.Image)
            .WithOne(i => i.DogFamily)
            .HasForeignKey<Image>(i => i.DogFamilyId)
            .IsRequired(false);
    }
}