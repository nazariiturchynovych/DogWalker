namespace DogWalker.Api.Application.ResultFactory;

using Constants;
using Domain.Results;
using IResult = DogWalker.Domain.Results.Abstraction.IResult;

public static class ResultFactory
  {
    public static Result<T> Success<T>(T data) => new Result<T>(data);

    public static Result Success() => new Result();

    public static Result<T> Failure<T>(
      string errorMessage,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result<T>((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "InnerError",
          errorMessage
        }
      }, exception, resultStatus);
    }

    public static Result<T> Failure<T>(
      string errorType,
      string errorMessage,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result<T>((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          errorType,
          errorMessage
        }
      }, exception, resultStatus);
    }

    public static Result<T> Failure<T>(
      IDictionary<string, string> errors,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result<T>(errors, exception, resultStatus);
    }

    public static Result<T> AsFailure<T>(IResult result)
    {
      if (!result.IsFailure)
        throw new ArgumentException("Can not create failure result from success result", nameof (result));
      return new Result<T>(result.Errors, result.Exception, result.Status);
    }

    public static Result Failure(
      string errorMessage,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "InnerError",
          errorMessage
        }
      }, exception, resultStatus);
    }

    public static Result Failure(
      string errorType,
      string errorMessage,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          errorType,
          errorMessage
        }
      }, exception, resultStatus);
    }

    public static Result Failure(
      IDictionary<string, string> errors,
      Exception? exception = null,
      ResultStatus resultStatus = ResultStatus.InvalidArgument)
    {
      return new Result(errors, exception, resultStatus);
    }
  }
