namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Routes;
using Domain.Entities.JobRequest.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RegularRouteConfiguration : IEntityTypeConfiguration<RegularRoute>
{
    public void Configure(EntityTypeBuilder<RegularRoute> builder)
    {
        builder.ToTable("RegularRoutes");


        builder.HasMany(rs => rs.JobDayRoutes)
            .WithOne(jds => jds.RegularRoute)
            .HasForeignKey(jds => jds.RegularRouteId);
    }
}