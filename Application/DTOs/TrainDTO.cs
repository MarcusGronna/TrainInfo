using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public record CreateTrainDto(string TrainNumber, TrainType TrainType);
    public record UpdateTrainDto(string TrainNumber, TrainType TrainType);
    public record TrainReadDto(Guid Id, string TrainNumber, DateTime Created, DateTime Updated, TrainType TrainType);
}
