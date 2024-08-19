using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Tests.Domain;

public class AirportCodeTests
{
    private const string TestCodeValue = "AAA";

    public AirportCodeTests() { }

    [Fact]
    public void CreateAirportCode_WithCorrectValue_ReturnsSuccess()
    {
        // act
        var result = AirportCode.Create(TestCodeValue);

        // assert
        Assert.NotNull(result);
        Assert.Equal(TestCodeValue, result.Value);
    }

    [Fact]
    public void CreateAirportCode_WithNullValue_ThrowException()
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => AirportCode.Create(null!));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Code.InvalidFormat, ex.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void CreateAirportCode_WithIncorrectLength_ThrowException(int difference)
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => AirportCode.Create(new string('A', AirportCode.Length + difference)));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Code.IncorrectLength, ex.Message);
    }

    [Theory]
    [InlineData("ab1")]
    [InlineData("AB_")]
    [InlineData("AB%")]
    public void CreateAirportCode_WithInvalidFormat_ThrowException(string value)
    {
        // act & assert
        var ex = Assert.Throws<StException>(() => AirportCode.Create(value));
        Assert.Equal(TestTask.Domain.Airports.Errors.Airport.Code.InvalidFormat, ex.Message);
    }
}
