namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobDayScheduleConfiguration : IEntityTypeConfiguration<JobDaySchedule>
{
    public void Configure(EntityTypeBuilder<JobDaySchedule> builder)
    {
        builder.ToTable("JobDaySchedules");
    }
}