using PizzaShop.DataAccess.Data;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User UpdateUserByEmail(ProfileViewModel model, string email);
}
