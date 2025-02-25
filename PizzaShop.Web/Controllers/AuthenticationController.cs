using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.DataAccess.Data;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Web.Controllers;

public class AuthenticationController: Controller
{
    private readonly PizzashopContext _context;
    private readonly IDataProtector _dataProtector;
    private readonly IConfiguration _config;
    private readonly IAuthenticationServices _IAuthService;
    private readonly IJWTService _IJWTService;

    public AuthenticationController(PizzashopContext context, IDataProtectionProvider dataProtectionProvider, IConfiguration config, IJWTService IJWTService)
    {
        _context = context;
        _dataProtector = dataProtectionProvider.CreateProtector("ResetPasswordProtector");
        _config = config;
        _IJWTService = IJWTService;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        var AuthToken = Request.Cookies["AuthToken"];

        if (!string.IsNullOrEmpty(AuthToken))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var isValidUser = await _IAuthService.VerifyUser(login);

            
            if (!string.IsNullOrEmpty(isValidUser.email))
            {
                // var verify = PasswordUtills.VerifyPassword(login.Password,user.Password);
                // if(!verify){
                //     ViewBag.Message = "Invalid Password";
                //     return View();
                // }
                // get Role
                // var role = await _context.Roles.FirstOrDefaultAsync(a => a.Id == user.Roleid);
                
                // create JWT Token 
                string token = _IJWTService.GenerateToken(isValidUser.email,isValidUser.role);
                
                if(token != ""){
                    TempData["token"] = token;
                    Response.Cookies.Append("AuthToken",token, new CookieOptions{
                        Secure = true,
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        HttpOnly = true
                    });
                }
                
                 var option = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(30),
                        Secure = true
                    };
                    Response.Cookies.Append("email", isValidUser.email, option);
                // Store Jwt Authentication Toke
                // using(var client = new HttpClient())
                // {
                //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                // }

                if (login.RememberMe)
                {
                    Response.Cookies.Append("AuthToken",token, new CookieOptions{
                        Secure = true,
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        HttpOnly = true
                    });
                }

                return RedirectToAction("Index", "Home");
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

    // [HttpGet]
    // public ActionResult ForgotPassword()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Email == model.Email);
    //         if (account == null)
    //         {
    //             ModelState.AddModelError("Email", "No account found with this email");
    //             return View(model);
    //         }

    //         string resetToken = GenerateResetToken(model.Email);
    //         string resetLink = $"http://localhost:5017/Authentication/ResetPassword?token={resetToken}";

    //         string subject = "Password reset request";
    //         string body = GetEmailTemplate(resetLink);

    //         SendMail(model.Email, subject, body);

    //         TempData["ForgotPasswordMsg"] = "Mail Sent Successfully. Please check your mail";
    //         return RedirectToAction("ForgotPassword");
    //     }
    //     return View(model);
    // }

    // [HttpGet]
    //  public IActionResult ResetPassword(string token)
    // {
    //     if (string.IsNullOrEmpty(token))
    //     {
    //         return BadRequest("Invalid reset token");
    //     }
    //     var model = new ResetPasswordViewModel { Token = token };
    //     Console.WriteLine(model);
    //     return View(model);
    // }

    // [HttpPost]
    // public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         string unprotectedToken;
    //         try
    //         {
    //             //decrypt the token
    //             unprotectedToken = _dataProtector.Unprotect(model.Token);
    //         }
    //         catch
    //         {
    //             ModelState.AddModelError("", "Invalid or expired password reset token");
    //             return View(model);
    //         }

    //         //token has {email} | {expiryticks}
    //         var parts = unprotectedToken.Split('|');
    //         if (parts.Length != 2 || !long.TryParse(parts[1], out long expiryTicks))
    //         {
    //             ModelState.AddModelError("error", "Invalid token");
    //             return View(model);
    //         }

    //         DateTime expiryDate = new DateTime(expiryTicks, DateTimeKind.Utc);      //converts expiry ticks into datetime object
    //         if (expiryDate < DateTime.UtcNow)
    //         {
    //             ModelState.AddModelError("error", "Password reset token has expired");
    //             return View(model);
    //         }

    //         string email = parts[0].Trim();
    //         var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
    //         if (account == null)
    //         {
    //             ModelState.AddModelError("error", "Account not found");
    //             return View(model);
    //         }

    //         account.Password = model.NewPassword;
    //         Console.WriteLine("Save changes called");
    //         _context.SaveChanges();

    //         TempData["SuccessMessage"] = "Your password has been reset successfully, you can now log in";
            
    //         return RedirectToAction("Login", "Authentication");
    //     }
    //     return View(model);
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public ActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

}
