using Microsoft.EntityFrameworkCore;
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
        _dbContext.Set<WeatherInformation>().Add(new WeatherInformation
        {
            City= request.City,
            Result = "Magari Amindi"
        });;

        await _dbContext.SaveChangesAsync();

        return new WeatherInfoResponse
        {
            Weather = "Magari Amindi"
        };
    }
}
