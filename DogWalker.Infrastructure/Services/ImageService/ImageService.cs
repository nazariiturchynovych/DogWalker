namespace DogWalker.Infrastructure.Services.ImageService;

using System.Data;
using DataBase.DogWalkerDbContext;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

public class ImageService<TEntity> : IImageService<TEntity>
    where TEntity : Entity, IImageEntity
{
    private readonly DogWalkerDbContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly DbSet<TEntity> Entities;

    public ImageService(DogWalkerDbContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
        Entities = context.Set<TEntity>();
    }


    public async Task<Stream> GetImageStreamAsync(TEntity entity)
    {
        // var dbContext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DogWalkerDbContext>();
        //
        // DbSet<TEntity> entities = dbContext.Set<TEntity>();

        var dbConnection = (NpgsqlConnection) _context.Database.GetDbConnection();

        var type = entity.GetType().Name;

        var command = new NpgsqlCommand($"SELECT \"ImageBytes\" FROM \"Image\" WHERE \"{type}Id\" = {entity.Id}", dbConnection);

        dbConnection.Open();

        var reader = await command.ExecuteReaderAsync();
        Stream result = null;
        if (reader.HasRows)
        {
// while (reader.Read())
// {
//     result = reader.GetStream(0);
// }
        }

        reader.Close();
        return result;
    }
}