namespace DogWalker.Domain.Repositories.UnitOfWork;

using Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

public interface IUnitOfWork
{
    IUserRepository GetUserRepository();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}