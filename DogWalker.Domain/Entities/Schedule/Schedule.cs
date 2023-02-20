namespace DogWalker.Domain.Entities.Schedule;

using Base;
using Walker;

public class Schedule : Entity
{
    public int WalkerId { get; set; }

    public Walker Walker { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}

public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
    All
}