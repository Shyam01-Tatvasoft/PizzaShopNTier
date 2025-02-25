namespace PizzaShop.Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class JWTService : Interfaces.IJWTService
{
    private readonly IConfiguration _config;

    public JWTService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(string email, string role){
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
         var authClaims = new List<Claim>{
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role),
         };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt: Issuer"],
            audience: _config["Jwt:Audience"],
            claims: authClaims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
