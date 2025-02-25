using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
}
