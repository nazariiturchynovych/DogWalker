namespace DogWalker.Domain.Entities.Base;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}