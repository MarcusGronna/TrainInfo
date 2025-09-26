using System;
using Application.Abstractions;
using Application.UseCases.Trains;
using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Application.UnitTest.Trains;

public class CreateTrainTests
{
	[Fact]
	public async Task Empty_TrainNumber_Throws_ArgumentException()
	{
		var repo = new Mock<ITrainRepository>(MockBehavior.Strict);
		var sut = new CreateTrain(repo.Object);

		var act = async () => await sut.HandleAsync(" ", TrainType.Passenger);

		await Assert.ThrowsAsync<ArgumentException>(act);
		repo.VerifyNoOtherCalls();
	}

	[Fact]
	public async Task Dublicate_TrainNumber_Throws_InvalidOperationException()
	{
		var trainNumber = "123";
		var repo = new Mock<ITrainRepository>(MockBehavior.Strict);

		// Setups to tell what to expect from this Mock, the behavior
			// Uses the method ExistsTrainNumberAsync and returns true to simulate an already existing entity with that same trainNumber
		repo.Setup(r => r.ExistsTrainNumberAsync(trainNumber, It.IsAny<CancellationToken>())).ReturnsAsync(true);

			// Uses the method AddAsync to simulate 
		//repo.Setup(r => r.AddAsync(
		//	It.Is<Train>(t => t.TrainNumber == trainNumber && t.TrainType == TrainType.Passenger),
		//	It.IsAny<CancellationToken>()))
		//	.Returns(Task.CompletedTask);

		// Instance of the ITrainRepository as a proxy
		var sut = new CreateTrain(repo.Object);

		var act = async () => await sut.HandleAsync(trainNumber, TrainType.Passenger);

		await Assert.ThrowsAsync<InvalidOperationException>(act);
		repo.Verify(r => r.ExistsTrainNumberAsync(trainNumber, It.IsAny<CancellationToken>()), Times.Once);
	}

	[Theory]
	[InlineData("123", TrainType.Passenger)]
	public async Task Can_Create_New_Train(string value, TrainType type)
	{
		var repo = new Mock<ITrainRepository>(MockBehavior.Strict);
		
		repo.Setup(x => x.ExistsTrainNumberAsync(value, It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);
		
		repo.Setup(x => x.AddAsync(
			It.Is<Train>(t => t.TrainNumber == value && t.TrainType == type), 
			It.IsAny<CancellationToken>()))
			.Returns(Task.CompletedTask);

		var sut = new CreateTrain(repo.Object);

		var act = async () => await sut.HandleAsync(value, type);

		var train = await act();

		Assert.NotNull(train);
		Assert.Equal(value, train.TrainNumber);
		Assert.Equal(type, train.TrainType);

		repo.Verify(r => r.ExistsTrainNumberAsync(value, It.IsAny<CancellationToken>()), Times.Once);
		repo.Verify(r => r.AddAsync(
			It.Is<Train>(t => t.TrainNumber == value && t.TrainType == type),
			It.IsAny<CancellationToken>()), Times.Once);
		repo.VerifyNoOtherCalls();
	}

	
}
