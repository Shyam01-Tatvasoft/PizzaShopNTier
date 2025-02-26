using Microsoft.AspNetCore.Mvc;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Web.Controllers;

public class ProfileController : Controller
{
    private readonly IJWTService _jwtService;
    private readonly IAuthenticationServices _authService;
    private readonly IProfileService _profileService;
    private readonly IAddressService _addressService;
    public ProfileController(IJWTService jwtService, IAuthenticationServices authService, IProfileService profileService, IAddressService addressService)
    {
        _jwtService = jwtService;
        _authService = authService;
        _profileService = profileService;
        _addressService = addressService;
    }

    public IActionResult Profile()
    {
        var email = Request.Cookies["email"];
        var AuthToken = Request.Cookies["AuthToken"];
        if (string.IsNullOrEmpty(AuthToken))
            return RedirectToAction("Login", "Authentication");
        Console.WriteLine(email);
        // var userEmail = _jwtService.ValidateToken(AuthToken);
        var userProfile = _profileService.GetUserProfile(email);

        var AllCountries = _addressService.GetAllCountries();
        
        // var AllStates = _addressService.GetAllStates();
        var AllStates = _addressService.GetAllStates(int.Parse(userProfile.Country));
        var AllCities = _addressService.GetAllCities(int.Parse(userProfile.State));
        ViewBag.AllCountries = AllCountries;
        ViewBag.AllCities = AllCities;
        ViewBag.AllStates = AllStates;
        ViewBag.Email = email;
        ViewBag.Role = userProfile.RoleId;
        ViewBag.FirstName = userProfile.FirstName;
        ViewBag.LastName = userProfile.LastName;
        return View(userProfile);
    }

    [HttpPost]
    public async Task<IActionResult> Profile(ProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var email = Request.Cookies["email"];

            // access email from token
            // var userEmail = _jwtService.ValidateToken(AuthToken);
            var account = _authService.FindAccount(email);
            var role = model.RoleId;
            var FirstName = model.FirstName;
            var LastName = model.LastName;

            if (account == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            bool isProfileUpdated = _profileService.UpdateProfileByEmail(model, email);

            if (!isProfileUpdated)
            {
                ViewData["ProfileError"] = "Profile is not Updated pls Try Again";
                return View();
            }



            ViewData["ProfileSuccessMessage"] = "Profile Updated SucessFully";

            var AllCountries = _addressService.GetAllCountries();
            var AllStates = _addressService.GetAllStates(int.Parse(model.Country));
            var AllCities = _addressService.GetAllCities(int.Parse(model.State));
            ViewBag.AllCountries = AllCountries;
            ViewBag.AllCities = AllCities;
            ViewBag.AllStates = AllStates;
            ViewBag.Email = email;
            ViewBag.Role = role;
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            return View();
        }
        else
        {
            return View();
        }
    }

    public ActionResult ChangePassword()
    {
        var AuthToken = Request.Cookies["AuthToken"];
        if (string.IsNullOrEmpty(AuthToken))
            return RedirectToAction("Login", "Authentication");

        var userEmail = _jwtService.ValidateToken(AuthToken);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var email = Request.Cookies["email"];

            // access email from token
            // var userEmail = _jwtService.ValidateToken(AuthToken);
            var account = _authService.FindAccount(email);
            if (account == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            // if (account.Password == model.CurrentPassword){
            //     account.Password = model.NewPassword;
            //     await _context.SaveChangesAsync();
            //     ViewData["ChangePassword"] = "Password Changed Successfully";
            //     return View();
            // }
            // else{
            //     ViewData["WrongPassword"] = "Wrong current Password Please Try Again !";
            //     return View();
            // }
        }
        return View();
    }

}
