using ApiFinancialControl.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiFinancialControl.Services;

public class TokenService
{
    public static string GenerateToken(User user)
    {
        var secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SecretHash"];

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials =
            new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
                    };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public static string GetIdFromToken(ClaimsPrincipal token)
    {
        return token.Claims.ElementAt(1).Value;

    }

}
