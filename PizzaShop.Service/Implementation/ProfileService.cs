using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Service.Implementation;

public class ProfileService: IProfileService
{
    private readonly IUserRepository _user;
    private readonly ICountryRepository _country;
    private readonly IRoleRepository _role;

    public ProfileService(IUserRepository user,ICountryRepository country)
    {
        _user = user;
    }

    public ProfileViewModel GetUserProfile(string? email)
    {
        var user = _user.GetUserByEmail(email);
        var profileModel = new ProfileViewModel
        {
            FirstName = user.Firstname,
            LastName = user.Lastname,
            UserName = user.Username,
            Phone = user.Phone,
            Country = user.Country,
            State = user.State,
            City = user.City,
            Address = user.Address,
            ZipCode = user.Zipcode,
            RoleId = user.Roleid.ToString()
        };
        Console.WriteLine(profileModel);
        return profileModel;
    }

    public bool UpdateProfileByEmail(ProfileViewModel model, string email)
    {
        var updatedUser = _user.UpdateUserByEmail(model, email);
        if (updatedUser != null)
            return true;
        return false;
    }
}
