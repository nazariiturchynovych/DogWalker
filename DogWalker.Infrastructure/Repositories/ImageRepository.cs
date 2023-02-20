namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Immage;
using Domain.Repositories;
using Repository.AbstractRepository;

public class ImageRepository : AbstractRepository<Image>, IImageRepository
{
    public ImageRepository(DogWalkerDbContext context)
        : base(context)
    {
    }
}