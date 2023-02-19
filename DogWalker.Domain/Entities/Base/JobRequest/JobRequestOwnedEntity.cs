namespace DogWalker.Domain.Entities.Base.JobRequest;

using Entities.JobRequest;

public abstract class JobRequestOwnedEntity : Entity, IJobRequestOwnedEntity
{
    public int JobRequestId { get; set; }

    public JobRequest JobRequest { get; set; }
}