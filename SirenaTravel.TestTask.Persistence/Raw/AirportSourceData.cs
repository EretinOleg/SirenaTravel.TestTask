using System.Text.Json.Serialization;

namespace SirenaTravel.TestTask.Persistence.Raw;

internal class AirportSourceData
{
    [JsonPropertyName("iata")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("location")]
    public Location? Location { get; set; }
}
