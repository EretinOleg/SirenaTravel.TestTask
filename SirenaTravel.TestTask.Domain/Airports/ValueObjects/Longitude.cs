using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Domain.Airports.ValueObjects;

public class Longitude: SimpleValueObject<double>
{
    public const double MinValue = -180.0d;

    public const double MaxValue = 180.0d;

    private Longitude(double value) : base(value)
    {
    }

    public static Longitude Create(double value)
    {
        if (value < MinValue || value > MaxValue)
            throw new StException(Errors.Airport.Longitude.OutOfRangeValue);

        return new Longitude(value);
    }
}
