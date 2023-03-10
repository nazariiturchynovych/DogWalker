namespace DogWalker.Domain.Entities.DogFamily;

using Base;
using Immage;
using Job;
using JobRequest;
using User;

public class DogFamily : Entity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int ImageId { get; set; }

    public int Adress { get; set; }

    public int DogsCount { get; set; }

    public ICollection<Dog> Dogs { get; set; }
        = new List<Dog>();

    public ICollection<JobRequest> JobRequests { get; set; }
        = new List<JobRequest>();

    public ICollection<Job> Jobs { get; set; }
        = new List<Job>();
}