namespace WeatherInfo.Services.Models;

public record WeatherInfoRequest
{
    public string City { get; init; } = string.Empty;
}

public record WeatherInfoResponse
{
    public string Weather { get; init; } = string.Empty;
}