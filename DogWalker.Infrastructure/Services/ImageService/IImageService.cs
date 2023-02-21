namespace DogWalker.Infrastructure.Services.ImageService;

using Domain.Entities.Base;

public interface IImageService<in TEntity> where TEntity : Entity ,IImageEntity
{
    public Task<Stream> GetImageStreamAsync(TEntity entity);
}