namespace DogWalker.Api.Application.Queries;

using Constants;
using Domain.DTO.User;
using Domain.Entities.User;
using Domain.Results.Abstraction;
using Infrastructure.Services.JWTTokenGeneratorService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record GoogleSignInQuery(string Email) : IRequest<IResult<SignInDto>>
{
    public class Handler : IRequestHandler<GoogleSignInQuery, IResult<SignInDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public Handler(UserManager<User> userManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<IResult<SignInDto>> Handle(GoogleSignInQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return ResultFactory.Failure<SignInDto>(UserErrorMessages.UserDoesNotExist);

            if (!user.GoogleAuth)
                return ResultFactory.Failure<SignInDto>(UserErrorMessages.UserGoogleAuthorizationFailed);

            return ResultFactory.Success(
                new SignInDto(_jwtTokenGeneratorService.GenerateToken(user)));
        }
    }
}