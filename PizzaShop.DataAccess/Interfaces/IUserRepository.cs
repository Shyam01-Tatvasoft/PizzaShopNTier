using PizzaShop.DataAccess.Data;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User UpdateUserProfileByEmail(ProfileViewModel model, string email);
    public List<UsersViewModel> GetUsers(string searchString, int pageIndex = 1, int pageSize = 3);
    public int getUsersCount(string searchString);
    public void DeleteUser(int id,int updatedbyId);
    public UpdateUserViewModel GetUpdateUserDetail(int id);
    public void UpdateUser(UpdateUserViewModel model, int? RoleId);
    public void CreateUser(CreateUserViewModel model,string email);
}
