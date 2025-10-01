using Application.Abstractions;
using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases.Trains
{
    public sealed class CreateTrain
    {
        private readonly ITrainRepository _repo;
        public CreateTrain(ITrainRepository repo) => _repo = repo;

        public async Task<Train> HandleAsync(string trainNumber, TrainType type, CancellationToken ct = default)
        {
            // Put in create method in domain instead
            if (string.IsNullOrWhiteSpace(trainNumber))
                throw new ArgumentException("TrainNumber is required.", nameof(trainNumber));

            if (await _repo.ExistsTrainNumberAsync(trainNumber, ct))
                throw new InvalidOperationException("TrainNumber already exists.");

            var entity = Train.Create(trainNumber, type);
            await _repo.AddAsync(entity, ct);
            return entity;
        }
    }
}
