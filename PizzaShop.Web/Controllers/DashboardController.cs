using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaShop.Service.Interfaces;

namespace PizzaShop.Web.Controllers;

public class DashboardController: Controller
{
    private readonly IJWTService _jwtService;

    public DashboardController(IJWTService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        var AuthToken = Request.Cookies["AuthToken"];
        if (string.IsNullOrEmpty(AuthToken))
            return RedirectToAction("Login", "Authentication");

        var userEmail = _jwtService.ValidateToken(AuthToken);
        return View();
    }
}
