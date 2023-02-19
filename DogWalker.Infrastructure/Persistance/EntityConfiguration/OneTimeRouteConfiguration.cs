namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OneTimeRouteConfiguration : IEntityTypeConfiguration<OneTimeRoute>
{
    public void Configure(EntityTypeBuilder<OneTimeRoute> builder)
    {
        builder.ToTable("OneTimeRoutes");
    }
}