namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Base;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DogWalkerDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IWalkerRepository _walkerRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IImageRepository _imageRepository;

    public UnitOfWork(
        DogWalkerDbContext context,
        IUserRepository userRepository,
        IWalkerRepository walkerRepository,
        IScheduleRepository scheduleRepository,
        IImageRepository imageRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _walkerRepository = walkerRepository;
        _scheduleRepository = scheduleRepository;
        _imageRepository = imageRepository;
    }


    public IUserRepository GetUserRepository() => _userRepository;
    public IWalkerRepository GetWalkerRepository() => _walkerRepository;
    public IScheduleRepository GetScheduleRepository() => _scheduleRepository;

    public IImageRepository GetImageRepository() => _imageRepository;


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}