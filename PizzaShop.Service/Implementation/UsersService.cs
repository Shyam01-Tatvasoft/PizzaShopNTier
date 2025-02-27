using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.Service.Implementation;

public class UsersService : IUsersService
{
    private readonly IUserRepository _user;
    private readonly IAccountRepository _account;

    public UsersService(IUserRepository user, IAccountRepository account)
    {
        _user = user;
        _account = account;
    }

    public List<UsersViewModel> GetUsers(string searchString, int pageIndex, int pageSize)
    {
        // here we return users which have isDeleted = false
        var userList = _user.GetUsers(searchString, pageIndex, pageSize);
        return userList;
    }

    public int GetUsersCount(string searchString)
    {
        return _user.getUsersCount(searchString);
    }

    public bool CreateUser(CreateUserViewModel model, string email)
    {
        var hashPassword = HashPassword(model.Password);
        model.Password = hashPassword;
        _user.CreateUser(model, email);
        _account.CreateAccount(model,email);

        // string subject = "Your new Account Details with Temporary password";
        // SendMail(email,subject,model.Password);
        return true;
    }

    public User GetUserByEmail(string email)
    {
        var user = _user.GetUserByEmail(email);
        return user;
    }
    
    public UpdateUserViewModel GetUpdateUserDetail(int id)
    {
        var updateUser = _user.GetUpdateUserDetail(id);
        return updateUser;
    }

    public void UpdateUser(UpdateUserViewModel model)
    {
        var user = _user.GetUserByEmail(model.Email);
        _user.UpdateUser(model,user.Roleid);
        _account.updateAccount(model,user.Roleid);
    }

    public void DeleteUser(int id, string email)
    {
        var user = _user.GetUserByEmail(email);

        // here i passed user id so we can put id or role in the place of updated By
        _user.DeleteUser(id, user.Id);
        _account.DeleteAccount(id, user.Id);
    }


    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

}
