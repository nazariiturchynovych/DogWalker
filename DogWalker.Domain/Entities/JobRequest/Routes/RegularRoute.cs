namespace DogWalker.Domain.Entities.JobRequest.Routes;

using Base.JobRequest;

public class RegularRoute : JobRequestOwnedEntity
{
    public ICollection<JobDayRoute> JobDayRoutes { get; set; }
        = new List<JobDayRoute>();
}