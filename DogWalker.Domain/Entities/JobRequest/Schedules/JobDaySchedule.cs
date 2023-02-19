namespace DogWalker.Domain.Entities.JobRequest.Schedules;

using Base;

public class JobDaySchedule : Entity
{
    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int RegularScheduleId { get; set; }

    public RegularSchedule RegularSchedule { get; set; }
}