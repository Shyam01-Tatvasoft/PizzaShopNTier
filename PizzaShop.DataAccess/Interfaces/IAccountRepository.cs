using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IAccountRepository
{
    public Account GetAccountByEmail(string email);
    public Account UpdatePassword(string email,string password);
}
