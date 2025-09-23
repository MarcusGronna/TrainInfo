namespace Domain.Entities
{
    /// <summary>
    /// Type of train in domain
    /// </summary>
    public enum TrainType
    {
        Passenger = 0,
        Service = 1,
    }


    /// <summary>
    /// Domain entity: POCO, no EF-dependencies in domain-layer
    /// </summary
    public class Train
    {
        public Guid Id { get; set; }
        public string TrainNumber { get; set; } = "";
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public TrainType TrainType { get; set; }

        //Olika DateTime??  Update och Create är olika?
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
