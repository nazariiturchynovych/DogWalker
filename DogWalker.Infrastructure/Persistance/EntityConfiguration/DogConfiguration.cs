namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.DogFamily;
using Domain.Entities.Immage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.ToTable("Dogs");

        builder.HasOne(d => d.Photo)
            .WithOne(i => i.Dog)
            .HasForeignKey<Image>(i => i.DogId)
            .IsRequired(false);

    }
}