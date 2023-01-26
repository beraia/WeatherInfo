using WeatherInfo.Services.Models;

namespace WeatherInfo.Services.Abstract;

public interface IWeatherInformationService
{
    Task<WeatherInfoResponse> GetWeatherInfo(WeatherInfoRequest request);
}
