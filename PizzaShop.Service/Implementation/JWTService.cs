namespace PizzaShop.Service.Implementation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;


public class JWTService : Interfaces.IJWTService
{
    private readonly IConfiguration _config;
    private readonly IRoleRepository _role;
    public JWTService(IConfiguration config, IRoleRepository role)
    {
        _config = config;
        _role = role;
    }

    public string GenerateToken(string email, int? role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var userRole = _role.GetRoleById(role);
        Console.WriteLine("issuer1" + _config["Jwt:Issuer"]);
        var authClaims = new List<Claim>{
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, userRole.Name),
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


    public string ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

        try
        {
            Console.WriteLine("Issuer 2" + _config["Jwt:Issuer"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return email;
        }
        catch (Exception ex)
        {
            // Log the exception details for debugging
            Console.WriteLine($"Token validation failed: {ex.Message}");
            return null;
        }
    }

    // public string ValidateToken(string token)
    // {
    //     if (string.IsNullOrEmpty(token))
    //         return null;

    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
    //     try
    //     {
    //         var validationParameters = new TokenValidationParameters
    //         {
    //             ValidateIssuerSigningKey = true,
    //             IssuerSigningKey = new SymmetricSecurityKey(key),
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidIssuer = _config["Jwt:Issuer"],
    //             ValidAudience = _config["Jwt:Audience"],
    //             ClockSkew = TimeSpan.Zero
    //         };

    //         // var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
    //         var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

    //         var userEmail = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    //         return userEmail;
    //     }
    //     catch
    //     {
    //         return null;
    //     }
    // }
}
