namespace DogWalker.Domain.Entities.JobRequest.Documents;

using Base;
using Immage;
using User;

public class PersonalIdentifier : Entity
{
    public PersonalIdentifierType PersonalIdentifierType { get; set; }

    public int ImageId { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}

public enum PersonalIdentifierType
{
Passport,
DriverLicense
}