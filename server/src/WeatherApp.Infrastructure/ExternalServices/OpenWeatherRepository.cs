using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Domain.Interfaces;


namespace WeatherApp.Infrastructure.ExternalServices
{
    public class OpenWeatherRepository:IWeatherRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public OpenWeatherRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }
        public async Task<string>GetWeatherAsync(string city)
        {
            var apiKey = _configuration["OpenWeather:ApiKey"];
            var url =
           $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
