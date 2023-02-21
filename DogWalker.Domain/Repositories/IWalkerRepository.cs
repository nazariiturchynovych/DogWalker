namespace DogWalker.Domain.Repositories;

using Entities.Schedule;
using Entities.Walker;

public interface IWalkerRepository : IAbstractRepository<Walker>
{
    public Task<Walker?> GetAsync(int id, CancellationToken cancellationToken = default);



    public Task<Walker?> GetWalkerWithAvatarAsync(int id, CancellationToken cancellationToken = default);

    public Task<ICollection<PossibleSchedule>?> GetWalkerSchedulesAsync(int id, CancellationToken cancellationToken = default);
}