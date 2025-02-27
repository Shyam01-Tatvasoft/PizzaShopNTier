using PizzaShop.DataAccess.Data;
using PizzaShop.ViewModels;

namespace PizzaShop.Service.Interfaces;

public interface IUsersService
{
    public List<UsersViewModel> GetUsers(string searchString, int pageIndex, int pageSize);

    public User GetUserByEmail(string email);

    public bool CreateUser(CreateUserViewModel model, string email);
    public int GetUsersCount(string searchString);
    public UpdateUserViewModel GetUpdateUserDetail(int id);
    public void UpdateUser(UpdateUserViewModel model);
    public void DeleteUser(int id, string email);
}
