namespace DogWalker.Domain.Entities.Schedule;

using Base;
using Walker;

public class PossibleSchedule : Entity
{
    public int WalkerId { get; set; }

    public Walker Walker { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}
