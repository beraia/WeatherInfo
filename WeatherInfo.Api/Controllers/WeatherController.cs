using Microsoft.AspNetCore.Mvc;
using WeatherInfo.Services.Abstract;
using WeatherInfo.Services.Models;

namespace WeatherInfo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherInformationService _weatherInformationService;

        public WeatherController(IWeatherInformationService weatherInformationService)
        {
            _weatherInformationService = weatherInformationService;
        }

        [HttpPost]
        [Route("GetInfo")]
        public async Task<IActionResult> GetWeatherInfo([FromBody] WeatherInfoRequest request)
        {
            if (request != null)
            {
                var response = await _weatherInformationService.GetWeatherInfo(request);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}