using Microsoft.AspNetCore.Mvc;

namespace PizzaShop.Service.Interfaces;


public interface IJWTService
{
    public string GenerateToken(string email, int? role);
    public string ValidateToken(string token);
}
