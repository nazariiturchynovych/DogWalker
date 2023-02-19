namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobDayRouteConfiguration : IEntityTypeConfiguration<JobDayRoute>
{
    public void Configure(EntityTypeBuilder<JobDayRoute> builder)
    {
        builder.ToTable("JobDayRoutes");
    }
}