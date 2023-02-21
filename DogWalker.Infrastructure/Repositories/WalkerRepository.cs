namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
using Domain.Entities.Schedule;
using Domain.Entities.Walker;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractRepository;

public class WalkerRepository : AbstractRepository<Walker>, IWalkerRepository
{
    private readonly DogWalkerDbContext _context;

    public WalkerRepository(DogWalkerDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Walker?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Walkers.Where(w => w.Id == id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<Walker?> GetWalkerWithAvatarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Walkers.Where(w => w.Id == id)
            .Include(w => w.Image)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<PossibleSchedule>?> GetWalkerSchedulesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Walkers.Where(w => w.Id == id)
            .Select(w => w.PossibleSchedules)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}