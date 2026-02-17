using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Interfaces;

namespace WeatherApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var result = await _weatherService.GetWeatherAsync(city);
        return Ok(result);
    }
}