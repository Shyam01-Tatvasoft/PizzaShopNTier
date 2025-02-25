using System.Net.Http.Headers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Service.Services;

public class AuthenticationService: IAuthenticationServices
{
    // private readonly IDataProtector _dataProtector;
    // private readonly IConfiguration _config;
    // private readonly IJWTService _jWTService;
    private readonly IAccountRepository _account;
    // private readonly IUserRepository _user;
    // private readonly IRoleRepository _role;

    public AuthenticationService(IAccountRepository account)
    {
        // _dataProtector = dataProtectionProvider.CreateProtector("ResetPasswordProtector");
        // _config = config;
        // _jWTService = jWTService;
        _account = account;
        // _role = role;
    }

    public async Task<(string email,string role)> VerifyUser(LoginViewModel login)
    {
        var email = login.Email;
        var password = login.Password;

        var account =   _account.GetAccountByEmail(email);

        if(account.Password == password){
            // var role = _role.GetRoleById(account.Roleid);
            return  (email, "Admin");
        }
      
        return (string.Empty,string.Empty);
    }

}