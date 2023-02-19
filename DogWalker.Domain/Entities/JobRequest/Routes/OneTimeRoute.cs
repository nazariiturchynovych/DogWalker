namespace DogWalker.Domain.Entities.JobRequest.Routes;

using Base.JobRequest;

public class OneTimeRoute : JobRequestOwnedEntity
{
    public DayOfWeek DayOfWeek { get; set; }

    public string StartPoint { get; set; }

    public string[] RelayPoints { get; set; }

    public string EndPoint { get; set; }
}