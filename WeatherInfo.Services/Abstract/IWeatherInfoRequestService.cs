using WeatherInfo.Services.Models;

namespace WeatherInfo.Services.Abstract;

public interface IWeatherInfoRequestService
{
    WeatherInfoResponse GetWeatherInfo(WeatherInfoRequest request);
}
