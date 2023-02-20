namespace DogWalker.Domain.Repositories;

using Entities.Walker;

public interface IWalkerRepository : IAbstractRepository<Walker>
{
    public Task<Walker?> GetAsync(int id, CancellationToken cancellationToken = default);

    public Task<Walker?> GetFullWalkerAsync(int id, CancellationToken cancellationToken = default);

    public Task<Walker?> GetWalkerWithSchedulesAsync(int id, CancellationToken cancellationToken = default);
}