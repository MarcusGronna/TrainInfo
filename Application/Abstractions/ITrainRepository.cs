using Domain.Entities;

namespace Application.Abstractions
{
    /// <summary>
    /// Repository-contract for Train. Small and intentional space. No EF-specific type leaking here. 
    /// </summary>
    public interface ITrainRepository
    {
        // READ
        Task<IReadOnlyList<Train>> ListAsync(CancellationToken ct = default);
        Task<Train?> GetByIdAsync(Guid id, CancellationToken ct = default);

        // WRITE
        Task AddAsync(Train entity, CancellationToken ct = default);
        Task UpdateAsync(Train entity, CancellationToken ct = default);
        Task RemoveAsync(Train entity, CancellationToken ct = default);

        // Helper method for safe query in Application-layer
        Task<bool> ExistsTrainNumberAsync(string trainNumber, CancellationToken ct = default);
    }
}
