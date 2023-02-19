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
public record SignInQuery
(
    string Email,
    string Password
) : IRequest<IResult<SignInDto>>
{
    public class Handler : IRequestHandler<SignInQuery, IResult<SignInDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public Handler(UserManager<User> userManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }
        public async Task<IResult<SignInDto>> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return ResultFactory.Failure<SignInDto>(UserErrorMessages.UserDoesNotExist);

            var logInResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (logInResult!)
                return ResultFactory.Failure<SignInDto>(UserErrorMessages.PasswordDoesNotMatch);

            return ResultFactory.Success(
                new SignInDto(_jwtTokenGeneratorService.GenerateToken(user)));
        }
    }

}