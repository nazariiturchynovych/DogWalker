namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Results.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;

public record ConfirmResetPasswordCommand(string Token, string UserId, string NewPassword) : IRequest<IResult>
{
    public class Handler : IRequestHandler<ConfirmResetPasswordCommand, IResult>
    {
        private readonly UserManager<User> _userManager;

        public Handler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IResult> Handle(ConfirmResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
                return ResultFactory.Failure(UserErrorMessages.UserDoesNotExist);

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            if (result.Succeeded!)
                return ResultFactory.Failure(UserErrorMessages.ResetPasswordFailed);

            return ResultFactory.Success();
        }
    }
}