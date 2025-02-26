using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.DataAccess.Data;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Web.Controllers;

public class AuthenticationController : Controller
{
    private readonly PizzashopContext _context;
    private readonly IDataProtector _dataProtector;
    private readonly IConfiguration _config;
    private readonly IAuthenticationServices _authService;
    private readonly IJWTService _IJWTService;

    public AuthenticationController(PizzashopContext context, IDataProtectionProvider dataProtectionProvider, IConfiguration config, IJWTService IJWTService, IAuthenticationServices iAuthService)
    {
        _context = context;
        _dataProtector = dataProtectionProvider.CreateProtector("ResetPasswordProtector");
        _config = config;
        _IJWTService = IJWTService;
        _authService = iAuthService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        var AuthToken = Request.Cookies["AuthToken"];

        if (!string.IsNullOrEmpty(AuthToken))
        {
            return RedirectToAction("Dashboard", "Dashboard");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var account = _authService.VerifyUser(login.Email, login.Password);

            if (account != null)
            {
                // create JWT Token 
                string token = _IJWTService.GenerateToken(account.Email, account.Roleid);

                if (string.IsNullOrEmpty(token))
                {
                    return View();

                }
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    Secure = true,
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    HttpOnly = true
                });

                var option = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    Secure = true
                };
                Response.Cookies.Append("Email", account.Email, option);

                // Store Jwt Authentication Token
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                if (login.RememberMe)
                {
                    Response.Cookies.Append("AuthToken", token, new CookieOptions
                    {
                        Secure = true,
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        HttpOnly = true
                    });
                }

                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ViewBag.Message = "UserName or password is Wrong";
                ModelState.AddModelError("", "Please Enter Valid Credentials");
                return View();
            }
        }
        return View(login);
    }

    [HttpGet]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var account = _authService.FindAccount(model.Email);
            if (account == null)
            {
                ModelState.AddModelError("Email", "No account found with this email");
                return View(model);
            }

            string resetToken = _authService.GenerateResetToken(model.Email);
            var fullUrl = this.Url.Action("ResetPassword", "Authentication", new { token = resetToken }, Request.Scheme);
            Console.WriteLine("ResetPass" + fullUrl);
            string resetLink = $"http://localhost:5017/Authentication/ResetPassword?token={resetToken}";

            string subject = "Password reset request";
            string body = GetEmailTemplate(resetLink);

            _authService.SendMail(model.Email, subject, body);

            TempData["ForgotPasswordMsg"] = "Mail Sent Successfully. Please check your mail";
            return RedirectToAction("ForgotPassword");
        }
        return View(model);
    }

    private static string GetEmailTemplate(string ResetLink)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "EmailTemplate.html");
        if (!System.IO.File.Exists(templatePath))
        {
            return "<p>Email template Not Fount</p>";
        }
        string emailbody = System.IO.File.ReadAllText(templatePath);
        return emailbody.Replace("{{Link}}", ResetLink);
    }

    [HttpGet]
    public IActionResult ResetPassword(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest("Invalid reset token");
        }
        var model = new ResetPasswordViewModel { Token = token };
        Console.WriteLine(model);
        return View(model);
    }

    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordViewModel model)
    {
        string email = _authService.ValidateResetToken(model.Token);

        if (string.IsNullOrEmpty(email))
        {
            TempData["ErrorMessage"] = "Token is Expired or Invalid Token";
            return View();
        }

        bool update = _authService.UpdatePassword(email, model.NewPassword);

        if (update)
        {
            ViewData["PasswordChangeMsg"] = "Password Updated Successfully";
            return RedirectToAction("Login", "Authentication");
        }

        return View();
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("AuthToken");
        Response.Cookies.Delete("email");
        return RedirectToAction("Login","Authentication");
    }
}
