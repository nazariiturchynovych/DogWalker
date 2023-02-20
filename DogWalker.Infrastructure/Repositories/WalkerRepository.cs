namespace DogWalker.Infrastructure.Repositories.UnitOfWork;

using DataBase.DogWalkerDbContext;
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

    public async Task<Walker?> GetFullWalkerAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Walkers.Where(w => w.Id == id)
            .Include(w => w.Jobs)
            .Include(w => w.PossibleSchedules)
            .Include(w => w.Avatar)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<Walker?> GetWalkerWithSchedulesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Walkers.Where(w => w.Id == id)
            .Include(w => w.PossibleSchedules)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}