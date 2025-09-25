using Domain.Enums;

namespace Domain.Entities
{


    /// <summary>
    /// Domain entity: POCO, no EF-dependencies in domain-layer
    /// </summary>
    public class Train
    {
        public Guid Id { get; private set; }
        public string TrainNumber { get; private set; } = string.Empty;
        public DateTime Created { get; private set; } // store as UTC
        public DateTime Updated { get; private set; } // store as UTC
        public TrainType TrainType { get; private set; }

        // EF Core needs a parameterless constructor. Why?
        private Train() { }

        
        // Factory method
        public static Train Create(
            string trainNumber,
            TrainType trainType)
        {
            return new Train()
            {
                Id = Guid.NewGuid(),
                TrainNumber = trainNumber,
                Created = DateTime.Now,
                TrainType = trainType
            };
        }
    }
}
