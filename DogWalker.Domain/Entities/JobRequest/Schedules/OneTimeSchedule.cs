namespace DogWalker.Domain.Entities.JobRequest.Schedules;

using Base.JobRequest;
using Schedule;

public class OneTimeSchedule : JobRequestOwnedEntity
{
    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}