namespace DogWalker.Domain.Results;

using System.Runtime.Serialization;
using Abstraction;
using Api.Application.Constants;

public class Result<TData> : Result, IResult<TData>, IBaseResult
{
    public Result(TData data) => Data = data;

    public Result(
        IDictionary<string, string> errors,
        Exception? exception = null,
        ResultStatus resultStatus = ResultStatus.InvalidArgument)
        : base(errors, exception, resultStatus)
    {
        Data = default(TData);
    }

    [DataMember]
    public TData Data { get; }

}