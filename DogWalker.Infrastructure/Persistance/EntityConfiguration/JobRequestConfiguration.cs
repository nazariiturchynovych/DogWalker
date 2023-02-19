namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.JobRequest;
using Domain.Entities.JobRequest.Routes;
using Domain.Entities.JobRequest.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobRequestConfiguration : IEntityTypeConfiguration<JobRequest>
{
    public void Configure(EntityTypeBuilder<JobRequest> builder)
    {
        builder.ToTable("JobRequests");

        builder.HasOne(jr => jr.OneTimeSchedule)
            .WithOne(ots => ots.JobRequest)
            .HasForeignKey<OneTimeSchedule>(ots => ots.JobRequestId);

        builder.HasOne(jr => jr.RegularSchedule)
            .WithOne(rs => rs.JobRequest)
            .HasForeignKey<OneTimeSchedule>(ots => ots.JobRequestId);

        builder.HasOne(jr => jr.OneTimeRoute)
            .WithOne(otr => otr.JobRequest)
            .HasForeignKey<OneTimeRoute>(otr => otr.JobRequestId);

        builder.HasOne(jr => jr.RegularSchedule)
            .WithOne(rs => rs.JobRequest)
            .HasForeignKey<RegularSchedule>(rs => rs.JobRequestId);

        builder.Property(jr => jr.Salary).IsRequired();

    }
}