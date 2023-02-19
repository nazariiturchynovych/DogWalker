namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.User;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractRepository;

public class UserRepository : AbstractRepository<User>, IUserRepository
{
    private readonly DogWalkerDbContext _context;

    public UserRepository(DogWalkerDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.Where(u => u.Id == id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }


    public async Task<User?> GetUserWithRoles(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.Where(u => u.Id == id)
            .Include(u => u.UserRoles)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}