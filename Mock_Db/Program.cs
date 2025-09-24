using Domain.Entities;

public class Mock_Db
{
        public List<Train> trainList = new()
     {
         Train.Create("12", TrainType.Passenger),
         Train.Create("14", TrainType.Service),
         Train.Create("32", TrainType.Passenger),
         Train.Create("434", TrainType.Service),
        Train.Create("34", TrainType.Passenger),
         Train.Create("2224", TrainType.Service),
     };
}
