using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Domain.Interfaces
{
    public interface IWeatherRepository
    {
        Task<string> GetWeatherAsync(string city);
    }
}
