// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618
namespace DogWalker.Domain.Entities.Walker;

using Base;
using Immage;
using Job;
using Schedule;
using User;

public class Walker : Entity
{
    public int UserId { get; set; }

    public User User { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public Image Avatar { get; set; }

    public ICollection<Schedule> PossibleSchedules { get; set; }
        = new List<Schedule>();

    public ICollection<Job> Jobs { get; set; }
        = new List<Job>();
}