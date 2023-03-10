namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Results.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record SignUpCommand
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int Age,
    string PhoneNumber
) : IRequest<IResult>
{
    public class Handler : IRequestHandler<SignUpCommand, IResult>
    {
        private readonly UserManager<User> _userManager;

        public Handler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                return ResultFactory.Failure(UserErrorMessages.UserAlreadyExist);
            }

            var userToAdd = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(userToAdd, request.Password);

            if (result.Succeeded!)
                return ResultFactory.Failure(UserErrorMessages.CreateUserFailed);

            return ResultFactory.Success();
        }
    }
}