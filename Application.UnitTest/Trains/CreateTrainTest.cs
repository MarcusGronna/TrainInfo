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

	[Theory]
	[InlineData("123", TrainType.Passenger)]
	public async Task Can_Create_New_Train(string value, TrainType type)
	{
		var repo = new Mock<ITrainRepository>(MockBehavior.Loose);
		var sut = new CreateTrain(repo.Object);

		var act = async () => await sut.HandleAsync(value, type);
		var train = await act();

		Assert.NotNull(train);
		Assert.Equal(value, train.TrainNumber);
		Assert.Equal(type, train.TrainType);
	}
}
