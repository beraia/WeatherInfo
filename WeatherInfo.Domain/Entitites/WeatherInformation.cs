using WeatherInfo.Domain.Shared;

namespace WeatherInfo.Domain.Entitites;

public class WeatherInformation : BaseEntity
{
    public string City { get; set; } = string.Empty;
    public float Temperature { get; set; } = float.MinValue;
    public string Result { get; set; } = string.Empty;
}
