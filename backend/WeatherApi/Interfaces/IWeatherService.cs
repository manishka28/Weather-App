namespace WeatherApi.Interfaces;

public interface IWeatherService
{
    Task<string> GetWeatherAsync(string city);
}