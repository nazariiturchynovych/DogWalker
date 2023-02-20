namespace DogWalker.Api.Application.Commands.Walker;

using Constants;
using Domain.Entities.Walker;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using ResultFactory;

public record CreateWalkerCommand(
    int UserId,
    string FirstName,
    string LastName,
    int Age
) : IRequest<IResult>
{
    public class Handler : IRequestHandler<CreateWalkerCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(CreateWalkerCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetUserRepository();

            var userExist = await userRepository.GetAsync(request.UserId, cancellationToken);

            if (userExist is null)
                return ResultFactory.Failure(UserErrorMessages.UserDoesNotExist);

            var walkerRepository = _unitOfWork.GetWalkerRepository();

            var walkerToAdd = new Walker()
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            walkerRepository.Add(walkerToAdd);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultFactory.Success();
        }
    }
}