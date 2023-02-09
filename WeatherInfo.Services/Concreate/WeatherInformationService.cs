using Newtonsoft.Json;
using WeatherInfo.Domain.Entitites;
using WeatherInfo.Infrastructure.Db;
using WeatherInfo.Services.Abstract;
using WeatherInfo.Services.Models;

namespace WeatherInfo.Services.Concreate;

public class WeatherInformationService : IWeatherInformationService
{
    private readonly WeatherInfoDbContext _dbContext;

    public WeatherInformationService(WeatherInfoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WeatherInfoResponse> GetWeatherInfo(WeatherInfoRequest request)
    {
        var client = new HttpClient();
        var httpRequest = client.GetAsync($"http://api.weatherapi.com/v1/current.json?key=8f3778f2f6fc4a2699a183311232601&q={request}&aqi=no");
        HttpResponseMessage response = httpRequest.Result;
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;
        var deserializedData = JsonConvert.DeserializeObject<WeatherInfoResponse>(result);


        _dbContext.Set<WeatherInformation>().Add(new WeatherInformation
        {
            City = request.City,
            Result = deserializedData.current.Condition.Text,
            Temperature = deserializedData.current.TempC
        });;

        await _dbContext.SaveChangesAsync();

        return new WeatherInfoResponse
        {
            location = new WeatherInfoResponse.Location
            {
                Name = deserializedData.location.Name
            },
            current = new WeatherInfoResponse.Current
            {
                TempC = deserializedData.current.TempC,
                Condition = deserializedData.current.Condition
            }
        };
    }
}
