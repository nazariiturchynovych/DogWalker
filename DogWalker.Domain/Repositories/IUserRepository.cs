namespace DogWalker.Domain.Repositories;

using Entities.User;

public interface IUserRepository : IAbstractRepository<User>
{
    public Task<User?> GetAsync(int id, CancellationToken cancellationToken = default);

    public Task<User?> GetUserWithRoles(int id, CancellationToken cancellationToken = default);
}