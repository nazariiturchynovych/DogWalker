// namespace DogWalker.Infrastructure.Extensions.MapExtensions;
//
// using System.Linq.Expressions;
// using DogWalker.Domain.DTO.Walker;
// using DogWalker.Domain.Entities.Walker;
//
// public static class WalkerMapExtension
// {
//     public static GetFullWalkerDto MapToGetWalkerDto(this Walker walker)
//     {
//         return new GetFullWalkerDto(
//             User: walker.User,
//             PossibleSchedules: walker.PossibleSchedules,
//             Jobs: walker.Jobs);
//     }
//
//     public static Expression<Func<Walker, GetFullWalkerDto>> MapWalkerToDto()
//     {
//         return w => new GetFullWalkerDto(
//             w.User,
//             w.PossibleSchedules,
//             w.Jobs);
//     }
// }