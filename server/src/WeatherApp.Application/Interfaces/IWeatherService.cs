using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(string city);
    }
}
