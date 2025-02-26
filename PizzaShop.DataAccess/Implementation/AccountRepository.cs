using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class AccountRepository: IAccountRepository
{
    private readonly PizzashopContext _context;

    public AccountRepository(PizzashopContext context)
    {
        _context = context;
    }

    public Account GetAccountByEmail(string email)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Email == email);
        return account;
    }

    public Account UpdatePassword(string email,string password)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Email == email);
        account.Password = password;
        _context.SaveChanges();
        return  account;
    }
}
