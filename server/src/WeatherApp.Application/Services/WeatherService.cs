using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Interfaces;
namespace WeatherApp.Application.Services
{
    public class WeatherService:IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public async Task<string>GetWeatherAsync(string city)
        {
            return await _weatherRepository.GetWeatherAsync(city);
        }
    }
}
