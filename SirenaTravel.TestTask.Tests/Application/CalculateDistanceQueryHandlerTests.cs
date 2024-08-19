using Moq;
using SirenaTravel.TestTask.Application.Airports.Queries.CalculateDistance;
using SirenaTravel.TestTask.Application.Core.Abstractions;
using SirenaTravel.TestTask.Domain.Airports;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Tests.Application;

public class CalculateDistanceQueryHandlerTests
{
    private const string FromAirportCodeValue = "AAA";
    private const string ToAirportCodeValue = "BBB";

    private readonly Mock<IAirportRepository> _mockAirportRepository;
    private readonly Mock<IDistanceCalculator> _mockIDistanceCalculator;

    public CalculateDistanceQueryHandlerTests()
    {
        _mockAirportRepository= new Mock<IAirportRepository>();
        _mockIDistanceCalculator = new Mock<IDistanceCalculator>();
    }

    [Fact]
    public async Task CalculateDistance_ForSameCodes_ReturnsZero()
    {
        // arrange
        var handler = new CalculateDistanceQueryHandler(
            _mockAirportRepository.Object,
            _mockIDistanceCalculator.Object);

        // act
        var distance = await handler.Handle(new CalculateDistanceQuery(FromAirportCodeValue, FromAirportCodeValue), CancellationToken.None);

        // assert
        Assert.Equal(0.0d, distance);
    }

    [Fact]
    public async Task CalculateDistance_ForNotExistingFromAirport_ThrowsException()
    {
        // arrange
        _mockAirportRepository
            .Setup(x => x.Load(AirportCode.Create(FromAirportCodeValue), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Airport?)null);

        var handler = new CalculateDistanceQueryHandler(
            _mockAirportRepository.Object,
            _mockIDistanceCalculator.Object);

        // act & assert
        var ex = await Assert.ThrowsAsync<StException>(() => handler.Handle(new CalculateDistanceQuery(FromAirportCodeValue, ToAirportCodeValue), CancellationToken.None));
        Assert.Equal(TestTask.Application.Airports.Errors.UnableToLoadAirportData, ex.Message);
    }

    [Fact]
    public async Task CalculateDistance_ForNotExistingToAirport_ThrowsException()
    {
        // arrange
        _mockAirportRepository
            .Setup(x => x.Load(AirportCode.Create(FromAirportCodeValue), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Airport.Create(AirportCode.Create(FromAirportCodeValue), 0.0d, 0.0d));

        _mockAirportRepository
            .Setup(x => x.Load(AirportCode.Create(ToAirportCodeValue), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Airport?)null);

        var handler = new CalculateDistanceQueryHandler(
            _mockAirportRepository.Object,
            _mockIDistanceCalculator.Object);

        // act & assert
        var ex = await Assert.ThrowsAsync<StException>(() => handler.Handle(new CalculateDistanceQuery(FromAirportCodeValue, ToAirportCodeValue), CancellationToken.None));
        Assert.Equal(TestTask.Application.Airports.Errors.UnableToLoadAirportData, ex.Message);
    }
}
