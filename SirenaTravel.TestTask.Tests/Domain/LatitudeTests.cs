using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Tests.Domain;

public class LatitudeTests
{
    private const double TestLatitudeValue = 50.0d;

    public LatitudeTests() { }

    [Theory]
    [InlineData(0.0d)]
    [InlineData(-50.0d)]
    [InlineData(50.0d)]
    [InlineData(-90.0d)]
    [InlineData(90.0d)]
    public void CreateLatitude_WithCorrectValue_ReturnsSuccess(double value)
    {
        // act
        var result = Latitude.Create(value);

        // assert
        Assert.NotNull(result);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void CreateLatitude_WithSmallValue_ThrowsException()
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => Latitude.Create(Latitude.MinValue - 1.0d));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Latitude.OutOfRangeValue, ex.Message);
    }

    [Fact]
    public void CreateLatitude_WithBigValue_ThrowsException()
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => Latitude.Create(Latitude.MaxValue + 1.0d));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Latitude.OutOfRangeValue, ex.Message);
    }
}
