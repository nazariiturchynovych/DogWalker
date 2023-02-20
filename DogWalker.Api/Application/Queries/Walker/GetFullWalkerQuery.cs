namespace DogWalker.Api.Application.Queries.Walker;

using Constants;
using Domain.Entities.Walker;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using ResultFactory;

public record GetFullWalkerQuery(int Id) : IRequest<IResult<Walker>>
{
    public class Handler : IRequestHandler<GetFullWalkerQuery, IResult<Walker>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<Walker>> Handle(GetFullWalkerQuery request, CancellationToken cancellationToken)
        {
            var walkerRepository = _unitOfWork.GetWalkerRepository();

            var walker = await walkerRepository.GetFullWalkerAsync(request.Id, cancellationToken);

            if (walker is null)
                return ResultFactory.Failure<Walker>(WalkerErrorConstants.WalkerDoesNotExist);

            return ResultFactory.Success(walker);
        }
    }
}