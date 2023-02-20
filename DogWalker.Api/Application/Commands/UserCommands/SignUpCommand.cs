namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record SignUpCommand
(
    string Email,
    string Password,
    string PhoneNumber
) : IRequest<IResult>
{
    public class Handler : IRequestHandler<SignUpCommand, IResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
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
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(userToAdd, request.Password);

            if (!result.Succeeded)
                return ResultFactory.Failure(UserErrorMessages.CreateUserFailed);

            return ResultFactory.Success();
        }
    }
}