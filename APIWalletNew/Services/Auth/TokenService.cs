using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIWalletNew.Models;
using APIWalletNew.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace APIWalletNew.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly string? _secretKey;
    private readonly int _accessTokenExpiryMinutes;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _secretKey = _configuration["JwtSettings:SecretKey"];
        _accessTokenExpiryMinutes = _configuration.GetValue<int>("JwtSettings:AccessTokenExpiryMinutes");
    }

    public string GenerateToken(User users)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()),
            new Claim(ClaimTypes.Name, users.Name)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_accessTokenExpiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}