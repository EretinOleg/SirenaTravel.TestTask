using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Domain.Airports.ValueObjects;

public class Longitude: SimpleValueObject<double>
{
    public const double MinValue = -180;

    public const double MaxValue = 180;

    private Longitude(double value) : base(value)
    {
    }

    public static Longitude Create(double value)
    {
        if (value < MinValue || value > MaxValue)
            throw new StException(Errors.Airport.Latitude.OutOfRangeValue);

        return new Longitude(value);
    }
}
