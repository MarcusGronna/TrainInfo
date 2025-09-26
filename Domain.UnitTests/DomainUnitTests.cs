using Domain.Entities;
using Domain.Enums;

namespace Domain.UnitTests
{
    public class DomainUnitTests
    {
        [Fact]
        public void Can_create_new_train()
        {
            // arrange
            string trainNumber = "123";
            var trainType = TrainType.Passenger;

            // act
            var train = Train.Create(trainNumber, trainType);


            // assert
            Assert.NotNull(train);
            Assert.Equal(train.TrainNumber, trainNumber);
            Assert.Equal(train.TrainType, trainType);
        }
    }
}
