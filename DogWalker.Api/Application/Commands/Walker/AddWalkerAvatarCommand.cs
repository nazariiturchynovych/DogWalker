namespace DogWalker.Api.Application.Commands.Walker;

using System.Net.Mime;
using Constants;
using Domain.Entities.Immage;
using Domain.Repositories.UnitOfWork;
using Domain.Results.Abstraction;
using Infrastructure.Services.CurrentUserService;
using MediatR;
using ResultFactory;

public record AddWalkerAvatarCommand(IFormFile FormFile, int Id) : IRequest<IResult>
{
    public class Handler : IRequestHandler<AddWalkerAvatarCommand, IResult>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        {
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(AddWalkerAvatarCommand request, CancellationToken cancellationToken)
        {
            var walkerRepository = _unitOfWork.GetWalkerRepository();

            var walker = await walkerRepository.GetAsync(request.Id, cancellationToken);

            if (walker is null)
                return ResultFactory.Failure(WalkerErrorConstants.WalkerDoesNotExist);

            var imageRepository = _unitOfWork.GetImageRepository();

            using var memoryStream = new MemoryStream();

            await request.FormFile.CopyToAsync(memoryStream, cancellationToken);

            var image = new Image()
            {
                WalkerId = walker.Id,
                ImageBytes = memoryStream.ToArray(),
            };
            imageRepository.Add(image);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultFactory.Success();
        }
    }
}