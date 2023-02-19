namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RegularScheduleConfiguration : IEntityTypeConfiguration<RegularSchedule>
{
    public void Configure(EntityTypeBuilder<RegularSchedule> builder)
    {
        builder.ToTable("RegularSchedules");


        builder.HasMany(rs => rs.JobDaySchedules)
            .WithOne(jds => jds.RegularSchedule)
            .HasForeignKey(jds => jds.RegularScheduleId);
    }
}