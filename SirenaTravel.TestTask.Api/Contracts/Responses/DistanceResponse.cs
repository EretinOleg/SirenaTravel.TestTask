using Newtonsoft.Json;

namespace SirenaTravel.TestTask.Api.Contracts.Responses
{
    public class DistanceResponse
    {
        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}
