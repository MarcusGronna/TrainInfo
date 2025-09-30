using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class TrainRepository : ITrainRepository
    {

        private readonly Data.TrainDbContext _db;
        public TrainRepository(Data.TrainDbContext db) => _db = db;

        // Read
        public async Task<IReadOnlyList<Train>> ListAsync(CancellationToken ct = default)
            => await _db.Trains.AsNoTracking().ToListAsync(ct);
        public Task<Train?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Trains.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, ct);

        // Helper
        public Task<bool> ExistsTrainNumberAsync(string trainNumber, CancellationToken ct = default)
            => _db.Trains.AnyAsync(t => t.TrainNumber == trainNumber, ct);

        // Write
        public async Task AddAsync(Train entity, CancellationToken ct = default)
            => await _db.Trains.AddAsync(entity, ct);

        public async Task UpdateAsync(Train entity, CancellationToken ct = default)
        {
            var existing = await _db.Trains.FirstOrDefaultAsync(t => t.Id == entity.Id, ct);
            if (existing is null) return;

            existing.UpdateTrainNumber(entity.TrainNumber);
            existing.UpdateTrainType(entity.TrainType);
        }
        
        public Task RemoveAsync(Train entity, CancellationToken ct = default)
        {
            // If entity not tracked, attach and mark for delete
            _db.Trains.Attach(entity);
            _db.Trains.Remove(entity);
            return Task.CompletedTask; // Commit in IUnitOfWork.SaveChangesAsync()
        }
    }
}
