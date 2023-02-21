namespace DogWalker.Api.Application.Commands.Walker;

using Constants;
using Domain.Entities.Schedule;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using ResultFactory;

public record AddWalkerPossibleSchedulesCommand(
    int WalkerId,
    List<PossibleSchedule> Schedules) : IRequest<IResult>
{
    public class Handler : IRequestHandler<AddWalkerPossibleSchedulesCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(AddWalkerPossibleSchedulesCommand request, CancellationToken cancellationToken)
        {
            var walkerRepository = _unitOfWork.GetWalkerRepository();

            var walkerExist = await walkerRepository.GetWalkerSchedulesAsync(request.WalkerId, cancellationToken);

            if (walkerExist is null)
                return ResultFactory.Failure(WalkerErrorConstants.WalkerDoesNotExist);

            var scheduleRepository = _unitOfWork.GetScheduleRepository();

             scheduleRepository.AddRange(request.Schedules);

             await _unitOfWork.SaveChangesAsync(cancellationToken);

             return ResultFactory.Success();
        }
    }
}