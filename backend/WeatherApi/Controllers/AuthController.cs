using Microsoft.AspNetCore.Mvc;
using WeatherApi.Helpers;
using WeatherApi.Models;
using System.Text.Json;

namespace WeatherApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtHelper _jwtHelper;
    private readonly string _userFile = "users.json"; // Path to JSON file

    public AuthController(JwtHelper jwtHelper)
    {
        _jwtHelper = jwtHelper;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterModel model)
    {
        List<RegisterModel> users = new List<RegisterModel>();

        if (System.IO.File.Exists(_userFile))
        {
            var jsonData = System.IO.File.ReadAllText(_userFile);
            if (!string.IsNullOrEmpty(jsonData))
            {
                users = JsonSerializer.Deserialize<List<RegisterModel>>(jsonData) ?? new List<RegisterModel>();
            }
        }

        // Check if username or email already exists
        if (users.Any(u => u.Username == model.Username || u.Email == model.Email))
        {
            return BadRequest("Username or email already exists");
        }

        // Add new user
        users.Add(model);

        // Save to JSON file
        var updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(_userFile, updatedJson);

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        List<RegisterModel> users = new List<RegisterModel>();

        if (System.IO.File.Exists(_userFile))
        {
            var jsonData = System.IO.File.ReadAllText(_userFile);
            if (!string.IsNullOrEmpty(jsonData))
            {
                users = JsonSerializer.Deserialize<List<RegisterModel>>(jsonData) ?? new List<RegisterModel>();
            }
        }

        var user = users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

        if (user != null)
        {
            var token = _jwtHelper.GenerateToken(user.Username);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}