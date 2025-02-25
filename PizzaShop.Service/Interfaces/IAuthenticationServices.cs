using PizzaShop.ViewModels;

namespace PizzaShop.Service.Interfaces;

public interface IAuthenticationServices
{
    public Task<(string email,string role)> VerifyUser(LoginViewModel login);
}
