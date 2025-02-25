using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class UserRepository: IUserRepository
{
    private readonly PizzashopContext _context;

    public UserRepository(PizzashopContext context)
    {
        _context = context;
    }
    public User GetUserByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        return  user;
    }
}
