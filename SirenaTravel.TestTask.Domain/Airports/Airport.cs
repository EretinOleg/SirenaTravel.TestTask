using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;

namespace SirenaTravel.TestTask.Domain.Airports;

public class Airport : Entity
{
    public AirportCode Code { get; private set; } = null!;

    public Coordinate Location { get; private set; }

    private Airport(AirportCode code, Coordinate location)
    {
        Code = code;
        Location = location;
    }

    public static Airport Create(string code, double latitude, double longitude)
    {
        return new Airport(
            AirportCode.Create(code),
            new Coordinate(Latitude.Create(latitude), Longitude.Create(longitude)));
    }
}
