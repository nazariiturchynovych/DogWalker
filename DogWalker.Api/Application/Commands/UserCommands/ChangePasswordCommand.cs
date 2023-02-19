namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Results.Abstraction;
using Infrastructure.Services.CurrentUserService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record ChangePasswordCommand
(
    string CurrentPassword,
    string NewPassword
) : IRequest<IResult>
{
    public class Handler : IRequestHandler<ChangePasswordCommand, IResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public Handler(UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<IResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var currentUserEmail = _currentUserService.Email;

            var currentUser = await _userManager.FindByEmailAsync(currentUserEmail);

            if (currentUser is null)
                return ResultFactory.Failure(UserErrorMessages.UserDoesNotExist);

            var passwordCheckingResult = await _userManager.CheckPasswordAsync(currentUser, request.CurrentPassword);

            if (passwordCheckingResult!)
                return ResultFactory.Failure(UserErrorMessages.PasswordDoesNotMatch);

            var passwordChangingResult = await _userManager.ChangePasswordAsync(
                currentUser,
                request.CurrentPassword,
                request.NewPassword);

            if (passwordChangingResult.Succeeded!)
                return ResultFactory.Failure(UserErrorMessages.PasswordChangeFailed);

            return ResultFactory.Success();
        }
    }
}