using PizzaShop.DataAccess.Data;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Interfaces;

public interface IAccountRepository
{
    public Account GetAccountByEmail(string email);
    public Account UpdatePassword(string email, string password);
    public void CreateAccount(CreateUserViewModel model,string email);
    public void updateAccount(UpdateUserViewModel model, int? roleId);
    public void DeleteAccount(int id, int updatedbyId);
}
