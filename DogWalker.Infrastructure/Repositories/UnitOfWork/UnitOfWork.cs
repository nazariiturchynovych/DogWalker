namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Base;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DogWalkerDbContext _context;
    private readonly IUserRepository _userRepository;

    public UnitOfWork(
        DogWalkerDbContext context,
        IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }


    public IUserRepository GetUserRepository()
    {
        return _userRepository;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

}