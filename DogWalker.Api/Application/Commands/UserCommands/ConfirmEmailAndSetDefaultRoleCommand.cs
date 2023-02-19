namespace DogWalker.Api.Application.Commands.UserCommands;

using Constants;
using Domain.Entities.User;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResultFactory;
using RoleType = Domain.Enums.RoleType;

public record ConfirmEmailAndSetDefaultRoleCommand
    (int UserId, string Token) : IRequest<IResult>
{
    public class Handler : IRequestHandler<ConfirmEmailAndSetDefaultRoleCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public Handler(IUnitOfWork unitOfWork , UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IResult> Handle(ConfirmEmailAndSetDefaultRoleCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetUserRepository();

            var user = await userRepository.GetUserWithRoles(request.UserId, cancellationToken);

            if (user is null)
                return ResultFactory.Failure(UserErrorMessages.UserDoesNotExist);

            if (user.EmailConfirmed)
                return ResultFactory.Failure(UserErrorMessages.EmailAlreadyConfirmed);

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (result.Succeeded!)
                return ResultFactory.Failure(UserErrorMessages.UserEmailConfirmFailed);

            user.UserRoles.Add(new UserRole()
            {
                RoleId = (int)RoleType.User
            });

            userRepository.Update(user);



            return ResultFactory.Success();
        }
    }
}