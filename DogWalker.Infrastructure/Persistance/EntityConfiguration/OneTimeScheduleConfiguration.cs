namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OneTimeScheduleConfiguration : IEntityTypeConfiguration<OneTimeSchedule>
{
    public void Configure(EntityTypeBuilder<OneTimeSchedule> builder)
    {
        builder.ToTable("OneTimeSchedules");
    }
}