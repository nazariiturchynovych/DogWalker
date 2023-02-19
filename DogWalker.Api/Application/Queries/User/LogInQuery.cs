namespace DogWalker.Api.Application.Queries;

using DogWalker.Api.Application.Constants;
using DogWalker.Api.Application.ResultFactory;
using DogWalker.Domain.DTO.User;
using DogWalker.Domain.Entities.User;
using DogWalker.Domain.Results.Abstraction;
using DogWalker.Infrastructure.Services.JWTTokenGeneratorService;
using MediatR;
using Microsoft.AspNetCore.Identity;

//TODO it is query
public record LogInQuery
(
    string Email,
    string Password
) : IRequest<IResult<LogInDto>>
{
    public class Handler : IRequestHandler<LogInQuery, IResult<LogInDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public Handler(UserManager<User> userManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }
        public async Task<IResult<LogInDto>> Handle(LogInQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return ResultFactory.Failure<LogInDto>(UserErrorMessages.UserDoesNotExist);

            var logInResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (logInResult!)
                return ResultFactory.Failure<LogInDto>(UserErrorMessages.PasswordDoesNotMatch);

            return ResultFactory.Success(
                new LogInDto(_jwtTokenGeneratorService.GenerateToken(user)));
        }
    }

}