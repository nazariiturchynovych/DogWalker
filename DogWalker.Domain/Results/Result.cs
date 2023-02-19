namespace DogWalker.Domain.Results;

using Api.Application.Constants;
using Abstraction;

public class Result : IResult
{
    public Result()
    {
        this.IsSuccess = true;
        this.Errors = (IDictionary<string, string>) new Dictionary<string, string>(0);
        this.Exception = (Exception) null;
    }

    public Result(
        IDictionary<string, string> errors,
        Exception? exception = null,
        ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
        this.IsSuccess = false;
        this.Errors = errors;
        this.Exception = exception;
        this.Status = resultStatus;
    }

    public bool IsSuccess { get; }

    public IDictionary<string, string> Errors { get; }

    public Exception? Exception { get; }

    public ResultStatus Status { get; }
}