namespace DogWalker.Domain.DTO.Walker;

using Entities.Job;
using Entities.Schedule;
using Entities.User;

public record GetWalkerDto(
    User User,
    ICollection<Schedule> PossibleSchedules,
    ICollection<Job> Jobs);