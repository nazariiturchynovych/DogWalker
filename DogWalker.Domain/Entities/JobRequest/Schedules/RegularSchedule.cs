namespace DogWalker.Domain.Entities.JobRequest.Schedules;

using Base.JobRequest;

public class RegularSchedule : JobRequestOwnedEntity
{
    public ICollection<JobDaySchedule> JobDaySchedules { get; set; }
        = new List<JobDaySchedule>();
}