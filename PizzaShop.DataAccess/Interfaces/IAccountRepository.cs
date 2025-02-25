using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IAccountRepository
{
    public Account GetAccountByEmail(string email);
}
