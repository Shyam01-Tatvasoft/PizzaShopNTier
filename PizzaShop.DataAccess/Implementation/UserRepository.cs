using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Implementation;

public class UserRepository : IUserRepository
{
    private readonly PizzashopContext _context;

    public UserRepository(PizzashopContext context)
    {
        _context = context;
    }
    public User GetUserByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User UpdateUserByEmail(ProfileViewModel model, string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        user.Firstname = model.FirstName;
        user.Lastname = model.LastName;
        user.Username = model.UserName;
        user.Phone = model.Phone;
        user.City = model.City;
        user.State = model.State;
        user.Country = model.Country;
        user.Address = model.Address;
        user.Zipcode = model.ZipCode;
        _context.SaveChangesAsync();

        return user;
    }
}
