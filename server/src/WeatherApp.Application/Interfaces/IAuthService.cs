using WeatherApp.Application.DTOs;

namespace WeatherApp.Application.Interfaces;

public interface IAuthService
{
    Task<string>LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);

}