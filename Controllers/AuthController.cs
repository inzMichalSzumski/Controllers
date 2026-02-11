using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Controllers.Models;
using Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var isAuthorized = _authService.ValidateCredentials(request.Email, request.Password);   

        if (isAuthorized)
        {
            var token = GenerateJwtToken(request.Email);
            return Ok(new { message = "Login successful", email = request.Email, token });
        }

        return Unauthorized(new { message = "Invalid email or password" });
    }

    private string GenerateJwtToken(string email)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("x7G#kP9$mN2@vQ5wL8^jR4&tY6*hB3!zX")); // Secret key for signing tokens (should be stored securely eg Azure Key Vault)

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Name, email)
        };

        var token = new JwtSecurityToken(
            issuer: "Controllers",
            audience: "Controllers",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}