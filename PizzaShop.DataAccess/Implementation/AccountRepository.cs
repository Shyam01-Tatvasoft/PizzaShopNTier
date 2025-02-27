using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Implementation;

public class AccountRepository : IAccountRepository
{
    private readonly PizzashopContext _context;
    private readonly IRoleRepository _role;

    public AccountRepository(PizzashopContext context, IRoleRepository role)
    {
        _context = context;
        _role = role;
    }

    public Account GetAccountByEmail(string email)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Email == email);
        return account;
    }

    public Account UpdatePassword(string email, string password)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Email == email);
        account.Password = password;
        _context.SaveChanges();
        return account;
    }

    public void CreateAccount(CreateUserViewModel model, string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        var role = _role.GetRoleById(user.Roleid);

        var newAccount = new Account
        {
            Email = model.Email,
            Roleid = _context.Roles.FirstOrDefault(r => r.Id == int.Parse(model.Role)).Id,
            Password = model.Password,
            Createdby = user.Id.ToString(),
            Createddate = DateTime.Now
        };
        _context.Accounts.Add(newAccount);
        _context.SaveChanges();
    }

    public void updateAccount(UpdateUserViewModel model, int? roleId)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Id == model.Id);
        var role = _role.GetRoleById(roleId);

        if (account != null)
        {
            account.Roleid = int.Parse(model.Role);
            account.Updatedby = role;
            account.Updateddate = DateTime.Now;

            _context.SaveChanges();
        }
    }
    public void DeleteAccount(int id, int updatedbyId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        var deletedBy = _context.Users.FirstOrDefault(u => u.Id == updatedbyId);
        var account = _context.Accounts.FirstOrDefault(a => a.Email == user.Email);
        var role = _role.GetRoleById(deletedBy.Roleid);

        account.Isdeleted = true;
        account.Updatedby = role;
        _context.SaveChanges();
    }
}
