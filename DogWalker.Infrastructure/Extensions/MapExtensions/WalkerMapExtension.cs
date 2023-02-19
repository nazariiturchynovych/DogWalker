namespace DogWalker.Infrastructure.Extensions.MapExtensions;

using System.Linq.Expressions;
using DogWalker.Domain.DTO.Walker;
using DogWalker.Domain.Entities.Walker;

public static class WalkerMapExtension
{
    public static GetWalkerDto MapToGetWalkerDto(this Walker walker)
    {
        return new GetWalkerDto(
            User: walker.User,
            PossibleSchedules: walker.PossibleSchedules,
            Jobs: walker.Jobs);
    }

    public static Expression<Func<Walker, GetWalkerDto>> MapWalkerToDto()
    {
        return w => new GetWalkerDto(
            w.User,
            w.PossibleSchedules,
            w.Jobs);
    }
}