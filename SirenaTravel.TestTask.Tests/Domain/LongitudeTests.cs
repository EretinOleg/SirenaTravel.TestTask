using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Tests.Domain;

public class LongitudeTests
{
    public LongitudeTests() { }

    [Theory]
    [InlineData(0.0d)]
    [InlineData(-50.0d)]
    [InlineData(50.0d)]
    [InlineData(-180.0d)]
    [InlineData(180.0d)]
    public void CreateLongitude_WithCorrectValue_ReturnsSuccess(double value)
    {
        // act
        var result = Longitude.Create(value);

        // assert
        Assert.NotNull(result);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void CreateLongitude_WithSmallValue_ThrowsException()
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => Longitude.Create(Longitude.MinValue - 1.0d));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Longitude.OutOfRangeValue, ex.Message);
    }

    [Fact]
    public void CreateLongitude_WithBigValue_ThrowsException()
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => Longitude.Create(Longitude.MaxValue + 1.0d));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Longitude.OutOfRangeValue, ex.Message);
    }
}
