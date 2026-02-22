using WeatherApp.Application.DTOs;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Interfaces;

namespace WeatherApp.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtTokenGenerator _jwtGenerator;

    public AuthService(
        IJwtTokenGenerator jwtGenerator,
        IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepo = userRepository;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userRepo.GetUsernameAsync(dto.Username);

        if (user == null || user.Password != dto.Password)
        {
            throw new Exception("Invalid Credentials");
        }

        return _jwtGenerator.GenerateToken(user);
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepo.GetUsernameAsync(dto.Username);

        if (existingUser != null)
        {
            throw new Exception("User already exists!");
        }

        var newUser = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password
        };

        await _userRepo.AddAsync(newUser);
    }
}