using System.Text.Json.Serialization;

namespace SirenaTravel.TestTask.Persistence.Raw;

internal class Location
{
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    [JsonPropertyName("lon")]
    public double Longitude { get; set; }
}
