namespace DogWalker.Domain.Entities.JobRequest;

using Base.AuditableDateEntity;
using DogFamily;
using Job;
using Routes;
using Schedules;

public class JobRequest : AuditableDateEntity
{
    public int RequiredAge { get; set; }

    public bool IsPersonalIdentifierRequired { get; set; }

    public RegularRoute? RegularRoute { get; set; }

    public OneTimeRoute? OneTimeRoute { get; set; }

    public RegularSchedule? RegularSchedule { get; set; }

    public OneTimeSchedule? OneTimeSchedule { get; set; }

    public double Salary { get; set; }

    public int DogFamilyId { get; set; }

    public DogFamily DogFamily { get; set; }

    public ICollection<Dog> Dogs { get; set; }

}