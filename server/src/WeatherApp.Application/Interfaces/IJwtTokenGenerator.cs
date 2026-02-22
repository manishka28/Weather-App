using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}