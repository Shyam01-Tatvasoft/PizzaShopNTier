using PizzaShop.DataAccess.Data;

namespace PizzaShop.Service.Interfaces;

public interface IAuthenticationServices
{
    public Account VerifyUser(string email, string password);
    public void SendMail(string ToEmail, string subject, string body);
    public string ValidateResetToken(string token);
    public string GenerateResetToken(string email);
    public bool UpdatePassword(string email, string password);
    public Account FindAccount(string email);
}
