namespace Application.Abstracions
{
    /// <summary>
    /// Thin Unit of Work. Exposes commit-point. Implemented by infrastructure (through EF Core DbContext).
    /// </summary>
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        Task<IDisposable> BeginTransactionAsync(CancellationToken ct = default);
    }
}
