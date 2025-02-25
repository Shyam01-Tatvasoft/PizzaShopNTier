using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Web.Models;

namespace PizzaShop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var AuthToken = Request.Cookies["AuthToken"];
        Console.WriteLine("AuthToken ", AuthToken);
        if (string.IsNullOrEmpty(AuthToken))
        {
            return RedirectToAction("Login", "Authentication");
        }
        else
        {
            return View();
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
