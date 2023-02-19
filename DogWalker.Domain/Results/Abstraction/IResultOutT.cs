namespace DogWalker.Domain.Results.Abstraction;

using Results.Abstraction;

public interface IResult<out T> :  IBaseResult
{
    T Data { get; }
}