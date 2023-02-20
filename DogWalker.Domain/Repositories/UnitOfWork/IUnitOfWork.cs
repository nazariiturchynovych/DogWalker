namespace DogWalker.Domain.Repositories.UnitOfWork;

using Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

public interface IUnitOfWork
{
    IUserRepository GetUserRepository();

    IWalkerRepository GetWalkerRepository();

    IScheduleRepository GetScheduleRepository();

    IImageRepository GetImageRepository();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}