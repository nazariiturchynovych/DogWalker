namespace DogWalker.Domain.Entities.Base.JobRequest;

using Entities.JobRequest;

public interface IJobRequestOwnedEntity : IEntity
{
    public int JobRequestId { get; set; }

    public JobRequest JobRequest { get; set; }
}