namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Schedule;
using Domain.Repositories;
using Repository.AbstractRepository;

public class ScheduleRepository : AbstractRepository<Schedule>,IScheduleRepository
{
    public ScheduleRepository(DogWalkerDbContext context)
        : base(context)
    {
    }
}