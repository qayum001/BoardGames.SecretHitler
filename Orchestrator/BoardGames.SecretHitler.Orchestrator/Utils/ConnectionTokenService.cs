using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BoardGames.SecretHitler.Orchestrator.Utils;

public class ConnectionTokenService(IConfiguration configuration) : IConnectionTokenService
{
    public string GetConnectionToken(string connectionId)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, connectionId),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ConnectionToken:Key"] ?? string.Empty));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "BoardGames.SecretHitler",
            audience: "BoardGames.SecretHitler",
            claims: claims,
            expires: DateTime.Now.AddHours(5), // Token expiration
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}