using System.Security.Cryptography;
using System.Text;
using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Service.Implementation;

public class ProfileService : IProfileService
{
    private readonly IUserRepository _user;
    private readonly ICountryRepository _country;
    private readonly IRoleRepository _role;
    private readonly IAccountRepository _account;

    public ProfileService(IUserRepository user, ICountryRepository country, IRoleRepository role, IAccountRepository account)
    {
        _user = user;
        _country = country;
        _role = role;
        _account = account;
    }

    public ProfileViewModel GetUserProfile(string? email)
    {
        var user = _user.GetUserByEmail(email);
        var role = _role.GetRoleById(user.Roleid);

        Console.WriteLine("role" + role);
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
            Role = role
        };
        Console.WriteLine(profileModel);
        return profileModel;
    }

    public bool UpdateProfileByEmail(ProfileViewModel model, string email)
    {
        var updatedUser = _user.UpdateUserProfileByEmail(model, email);
        if (updatedUser != null)
            return true;
        return false;
    }

    public string ChangePassword(ChangePasswordViewModel model, string email)
    {
        var account = _account.GetAccountByEmail(email);
        if (account == null)
            return "user not found";
        var isOldPasswordValid = VerifyPassword(model.CurrentPassword, account.Password);
        if (!isOldPasswordValid)
            return "Current Password Is Incorrect";
        var hashpassword = HashPassword(model.NewPassword);

        var passwordUpdate = _account.UpdatePassword(email, hashpassword);
        if (passwordUpdate.Password == hashpassword)
            return "success";
        return "fail";
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    private static bool VerifyPassword(string inputPassword, string storedHash) //admin@123
    {
        return HashPassword(inputPassword) == storedHash;
    }

}
