namespace DogWalker.Domain.Entities.Job;

using Base.AuditableDateEntity;
using DogFamily;
using JobRequest;
using Walker;

public class Job : AuditableDateEntity
{
    public int DogFamilyId { get; set; }

    public DogFamily DogFamily { get; set; }

    public int WalkerId { get; set; }

    public Walker Walker { get; set; }

    public int JobRequestId { get; set; }

    public JobRequest JobRequest { get; set; }

    public decimal Salary { get; set; }

    public string? Comment { get; set; }

    public JobStatus Status { get; set; }
}

public enum JobStatus
{
    Pending,
    Applied,
    Declined
}