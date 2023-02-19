namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Results.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record GoogleSignUpCommand(string Email) : IRequest<IResult>
{
    public class Handler : IRequestHandler<GoogleSignUpCommand, IResult>
    {
        private readonly UserManager<User> _userManager;

        public Handler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IResult> Handle(GoogleSignUpCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                return ResultFactory.Failure(UserErrorMessages.UserAlreadyExist);
            }

            var userToAdd = new User()
            {
                Email = request.Email,
                UserName = request.Email,
                GoogleAuth = true,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userToAdd);

            if (result.Succeeded!)
                return ResultFactory.Failure(UserErrorMessages.CreateUserFailed);

            return ResultFactory.Success();
        }
    }
}