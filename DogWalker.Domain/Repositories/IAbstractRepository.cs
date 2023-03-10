namespace DogWalker.Domain.Repositories;

using System.Linq.Expressions;

public interface IAbstractRepository<TEntity>
{
    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    public void UpdateRange(ICollection<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(ICollection<TEntity> collection);
}