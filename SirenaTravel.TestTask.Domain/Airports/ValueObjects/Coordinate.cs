using CSharpFunctionalExtensions;

namespace SirenaTravel.TestTask.Domain.Airports.ValueObjects;

public class Coordinate: ValueObject
{
    public Latitude Latitude { get; private set; }

    public Longitude Longitude { get; private set; }

    public Coordinate(Latitude latitude, Longitude longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }
}
