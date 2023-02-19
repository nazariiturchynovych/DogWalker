namespace DogWalker.Domain.Results.Abstraction;

using Api.Application.Constants;

public interface IBaseResult
{
    bool IsSuccess { get; }

    bool IsFailure => !this.IsSuccess;

    IDictionary<string, string> Errors { get; }

    ResultStatus Status { get; }

    Exception? Exception { get; }
}