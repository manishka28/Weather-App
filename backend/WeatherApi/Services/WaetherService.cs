using WeatherApi.Interfaces;

namespace WeatherApi.Services;

public class WeatherService : IWeatherService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;

    public WeatherService(IConfiguration config)
    {
        _config = config;
        _httpClient = new HttpClient();
    }

    public async Task<string> GetWeatherAsync(string city)
    {
        var apiKey = _config["OpenWeather:ApiKey"];
        var url =
            $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync(); // reads as string often json
    }
}