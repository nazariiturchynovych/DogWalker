namespace DogWalker.Api.Application.Queries.Walker;

using Constants;
using Domain.DTO.Walker;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using MediatR;
using ResultFactory;

public record GetWalkerWithAvatarQuery(int Id) : IRequest<IResult<GetWalkerWithAvatarDto>>
{
    public class Handler : IRequestHandler<GetWalkerWithAvatarQuery, IResult<GetWalkerWithAvatarDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<GetWalkerWithAvatarDto>> Handle(GetWalkerWithAvatarQuery request, CancellationToken cancellationToken)
        {
            var walkerRepository = _unitOfWork.GetWalkerRepository();

            var walkerWithAvatar = await walkerRepository.GetWalkerWithAvatarAsync(request.Id, cancellationToken);

            if (walkerWithAvatar is null)
                return ResultFactory.Failure<GetWalkerWithAvatarDto>(WalkerErrorConstants.WalkerDoesNotExist);


            var walkerWithAvatarDto = new GetWalkerWithAvatarDto(
                walkerWithAvatar.FirstName,
                walkerWithAvatar.LastName,
                walkerWithAvatar.Age,
                new AvatarDto(walkerWithAvatar.Image.ImageBytes));


            return ResultFactory.Success(walkerWithAvatarDto);
        }
    }
}