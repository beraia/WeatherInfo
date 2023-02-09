using Newtonsoft.Json;

namespace WeatherInfo.Services.Models;

public record WeatherInfoRequest
{
    public string City { get; init; } = string.Empty;
}

public record WeatherInfoResponse
{
    public Location location { get; set; }
    public Current current { get; set; }
    public class Location
    {
        [JsonProperty ("name")]
        public string Name { get; set; }
    }

    public class Current
    {
        [JsonProperty ("temp_c")]
        public float TempC { get; set; }

        [JsonProperty ("condition")]
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        [JsonProperty ("text")]
        public string Text { get; set; }
    }

}