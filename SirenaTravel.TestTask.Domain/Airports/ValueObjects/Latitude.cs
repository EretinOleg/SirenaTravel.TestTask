using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Domain.Airports.ValueObjects;

public class Latitude : SimpleValueObject<double>
{
    public const double MinValue = -90;

    public const double MaxValue = 90;

    private Latitude(double value) : base(value)
    {
    }

    public static Latitude Create(double value)
    {
        if (value < MinValue || value > MaxValue)
            throw new StException(Errors.Airport.Latitude.OutOfRangeValue);

        return new Latitude(value);
    }
}
