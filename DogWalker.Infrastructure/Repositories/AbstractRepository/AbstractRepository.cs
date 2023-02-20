namespace DogWalker.Infrastructure.Repository.AbstractRepository;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Base;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class AbstractRepository<TEntity> : IAbstractRepository<TEntity>
where TEntity : class, IEntity
{
    private readonly DogWalkerDbContext _context;
    protected readonly DbSet<TEntity> Entities;

    public AbstractRepository(
        DogWalkerDbContext context)
    {
        _context = context;
        Entities = context.Set<TEntity>();
    }


    public void Add(TEntity entity)
        => Entities.AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));

    public void AddRange(IEnumerable<TEntity> entities)
        =>  _context.AddRangeAsync(entities);

    public void Update(TEntity entity)
        => Entities.Update(entity ?? throw new ArgumentNullException(nameof(entity)));

    public  void UpdateRange(ICollection<TEntity> entities)
        =>  Entities.UpdateRange(entities ?? throw new ArgumentNullException(nameof(entities)));

    public void Remove(TEntity entity)
        => Entities.Remove(entity ?? throw new ArgumentNullException(nameof(entity)));

    public void RemoveRange(ICollection<TEntity> collection)
        => Entities.RemoveRange(collection ?? throw new ArgumentNullException(nameof(collection)));

}