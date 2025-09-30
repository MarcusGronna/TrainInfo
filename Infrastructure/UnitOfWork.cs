using Application.Abstractions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TrainDbContext _db;

    internal UnitOfWork(TrainDbContext db) => _db = db;

    // Central commit point
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);

    // Transaction if needed
    public async Task<IDisposable> BeginTransactionAsync(CancellationToken ct = default)
    {
        IDbContextTransaction tx = await _db.Database.BeginTransactionAsync(ct);
        return tx;
    }

    public void Dispose() => _db.Dispose();

}

