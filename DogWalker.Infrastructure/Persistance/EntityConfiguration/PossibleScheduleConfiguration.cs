namespace DogWalker.Infrastructure.DataBase.DogWalkerDbContext.EntityConfiguration;

using Domain.Entities.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PossibleScheduleConfiguration : IEntityTypeConfiguration<PossibleSchedule>
{
    public void Configure(EntityTypeBuilder<PossibleSchedule> builder)
    {
        builder.ToTable("PossibleSchedules");

    }
}