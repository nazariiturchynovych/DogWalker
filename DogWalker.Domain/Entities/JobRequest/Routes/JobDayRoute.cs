namespace DogWalker.Domain.Entities.JobRequest.Routes;

using Base;

public class JobDayRoute : Entity
{
    public DayOfWeek DayOfWeek { get; set; }

    public string StartPoint { get; set; }

    public string[] RelayPoints { get; set; }

    public string EndPoint { get; set; }

    public int RegularRouteId { get; set; }

    public RegularRoute RegularRoute { get; set; }
}

public record RelayPoint(string Point);