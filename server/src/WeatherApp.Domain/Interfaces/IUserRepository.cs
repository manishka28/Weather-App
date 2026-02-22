using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUsernameAsync(string username);
    Task AddAsync(User user);
}