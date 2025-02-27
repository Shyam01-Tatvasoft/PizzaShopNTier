using Microsoft.AspNetCore.Mvc;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Web.Controllers;

public class UsersController : Controller
{
    private readonly IUsersService _user;
    private readonly IAccountRepository _account;
    private readonly IAddressService _addressService;

    public UsersController(IUsersService user, IAccountRepository account, IAddressService addressService)
    {
        _user = user;
        _account = account;
        _addressService = addressService;
    }


    [HttpGet]
    public async Task<IActionResult> Index(string searchString, int pageIndex = 1, int pageSize = 3)
    {
        var AuthToken = Request.Cookies["AuthToken"];
        if (string.IsNullOrEmpty(AuthToken))
        {
            return RedirectToAction("Login", "Authentication");
        }

        var userList = _user.GetUsers(searchString, pageIndex, pageSize);

        var count = _user.GetUsersCount(searchString);
        var totalPage = (int)Math.Ceiling(count / (double)pageSize);
        ViewBag.Count = count;
        ViewBag.pageIndex = pageIndex;
        ViewBag.pageSize = pageSize;
        ViewBag.TotalPage = totalPage;
        ViewBag.SearchString = searchString;

        return View(userList);
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        var email = Request.Cookies["email"];
        var AuthToken = Request.Cookies["AuthToken"];
        if (String.IsNullOrEmpty(AuthToken))
        {
            return RedirectToAction("Login", "Authentication");
        }

        var AllCountries = _addressService.GetAllCountries();
        var AllStates = _addressService.GetAllStates(0);
        var AllCities = _addressService.GetAllCities(0);
        ViewBag.AllCountries = AllCountries;
        ViewBag.AllCities = AllCities;
        ViewBag.AllStates = AllStates;

        return View();
    }

    [HttpGet]
    public JsonResult GetStates(int countryId)
    {
        var states = _addressService.GetAllStates(countryId);
        ViewBag.AllStates = states;
        return Json(states);
    }

    [HttpGet]
    public JsonResult GetCities(int stateId)
    {
        var cities = _addressService.GetAllCities(stateId);
        ViewBag.AllCities = cities;
        return Json(cities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var email = Request.Cookies["email"];

            // also need to verify is it Admin or not
            if (String.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Authentication");
            }

            var account = _account.GetAccountByEmail(email);
            if (account.Roleid == 3)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }

            var user = _account.GetAccountByEmail(model.Email);
            if (user != null)
            {
                ViewData["UserExistMsg"] = "User Already Exist";
                return View();
            }

            bool newUser = _user.CreateUser(model, email);

            ViewData["SuccessMessage"] = "User Created Successfully";
            if (newUser)
                return RedirectToAction("Index", "Users");
        }
        var AllCountries = _addressService.GetAllCountries();
        var AllStates = _addressService.GetAllStates(-1);
        var AllCities = _addressService.GetAllCities(-1);
        ViewBag.AllCountries = AllCountries;
        ViewBag.AllCities = AllCities;
        ViewBag.AllStates = AllStates;
        return View();
    }


    [HttpGet]
    public IActionResult UpdateUser(int Id)
    {
        var email = Request.Cookies["email"];
        if (String.IsNullOrEmpty(email))
        {
            return RedirectToAction("Login", "Authentication");
        }
        var user = _user.GetUserByEmail(email);
        // also need to verify is it Admin or not
        if (user == null)
        {
            return RedirectToAction("Login", "Authentication");
        }


        var AllCountries = _addressService.GetAllCountries();
        var AllStates = _addressService.GetAllStates(-1);
        var AllCities = _addressService.GetAllCities(-1);
        ViewBag.AllCountries = AllCountries;
        ViewBag.AllCities = AllCities;
        ViewBag.AllStates = AllStates;

        UpdateUserViewModel updateUser = _user.GetUpdateUserDetail(Id);
        return View(updateUser);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var email = Request.Cookies["email"];
            if (String.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Authentication");
            }
            var user = _user.GetUserByEmail(email);

            
            _user.UpdateUser(model);

            return RedirectToAction("Index", "Users");
        }
        else
        {
            var AllCountries = _addressService.GetAllCountries();
            var AllStates = _addressService.GetAllStates(-1);
            var AllCities = _addressService.GetAllCities(-1);
            ViewBag.AllCountries = AllCountries;
            ViewBag.AllCities = AllCities;
            ViewBag.AllStates = AllStates;
            return View();
        }
    }

    public async Task<IActionResult> DeleteUser(int Id)
    {
        var email = Request.Cookies["email"];
        var account = _account.GetAccountByEmail(email);

        if (account == null)
        {
            return RedirectToAction("Login", "Authentication");
        }

        _user.DeleteUser(Id, email);
        // var deleteUser = _context.Users.FirstOrDefault(u => u.Id == Id);
        // var deleteAccount = _context.Accounts.FirstOrDefault(a => a.Email == deleteUser.Email);

        // deleteUser.Isdeleted = true;
        // deleteAccount.Isdeleted = true;
        // _context.SaveChanges();
        // ViewData["SuccessMsg"] = "User Deleted Successfully";
        return RedirectToAction("Index", "Users");
    }


    //  public void SendMail(string ToEmail, string subject, string tempPassword)
    // {
    //     string SenderMail = "test.dotnet@etatvasoft.com";
    //     string SenderPassword = "P}N^{z-]7Ilp";
    //     string Host = "mail.etatvasoft.com";
    //     int Port = 587;

    //     var smtpClient = new SmtpClient(Host)
    //     {
    //         Port = Port,
    //         Credentials = new NetworkCredential(SenderMail, SenderPassword),
    //     };

    //     MailMessage mailMessage = new MailMessage();
    //     mailMessage.From = new MailAddress(SenderMail);
    //     mailMessage.To.Add(ToEmail);
    //     mailMessage.Subject = subject;
    //     mailMessage.IsBodyHtml = true;
    //     string mailBody = $"Hello Your Account has been created and your Temporary Password is {tempPassword}";
    //     mailMessage.Body = mailBody;

    //     smtpClient.Send(mailMessage);
    // }
}
